using System;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

public abstract class InstrumentBase
{
    protected SerialPort serialPort;

    public bool IsConnected => serialPort != null && serialPort.IsOpen;
    /*
    private string portName;
    private string newLine = "\r\n";
    private Handshake handshake = Handshake.None;
    private int baudRate = 9600;
    private Parity parity = Parity.None;
    private int dataBits = 8;
    private StopBits stopBits = StopBits.One;
    private int timeout = 2000;
    */
    public virtual bool Connect(
        string portName,
        string newLine = "\r\n",
        Handshake handshake = Handshake.None,
        int baudRate = 9600,
        Parity parity = Parity.None,
        int dataBits = 8,
        StopBits stopBits = StopBits.One,
        int timeout = 2000)
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
            {
                Handshake = handshake,
                ReadTimeout = timeout,
                WriteTimeout = timeout,
                NewLine = newLine
            };            
            serialPort.Open();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка підключення: {ex.Message}",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            return false;
        }
    }
    public bool ConnectAndCheck(
        string portName,
        string expectedId,
        string newLine = "\r\n",
        Handshake handshake = Handshake.None,
        int baudRate = 9600,
        Parity parity = Parity.None,
        int dataBits = 8,
        StopBits stopBits = StopBits.One,
        int timeout = 2000)
    {
        try
        {
            serialPort = new SerialPort(portName, 9600);
            serialPort.ReadTimeout = timeout;
            serialPort.WriteTimeout = timeout;
            serialPort.Open();

            serialPort.WriteLine("*IDN?");
            string response = serialPort.ReadLine();

            if (response.Contains(expectedId))
                return true;
            else 
            {
                Disconnect();
                throw new Exception($"Невідомий пристрій: {response}");
            }
                
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка підключення: {ex.Message}",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    public virtual void Disconnect()
    {
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
    private Random _rnd = new Random();
    public virtual string SendCommand(string command, int waitMs = 20)
    {
        if (!IsConnected) return null;

        try
        {
            // Скидаємо буфери
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            // Відправляємо команду
            serialPort.WriteLine(command);
            // Очікуємо, поки прилад відповість
            if (waitMs > 0)
            {
                System.Threading.Thread.Sleep(waitMs);
            }
            

            // Читаємо все з буфера
            string response = serialPort.ReadExisting().Trim();
            //response = $"Good - {command}";
            // Додатково можна перевірити, чи відповідь порожня
            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("Увага: відповідь відсутня або порожня");
                return null;
            }

            return response;
            //return serialPort.ReadLine(); // для SCPI-приладів
            // Наприклад, опір 1–10 кОм


            /*
            if (command == "EMUL-Keithley") { return $"{1000.0 + _rnd.NextDouble() * 9000.0} OHM"; }
            if (command == "EMUL-LakeShore") { return $"{290.0 + _rnd.NextDouble() * 20.0} OHM"; }
            else
            {
                return serialPort.ReadLine();
            }
            */
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Помилка: таймаут RS232");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка обміну: {ex.Message}");
            return null;
        }
    }
    public virtual string SendCommandTest(string command)
    {
        if (!IsConnected) return null;

        try
        {
            serialPort.WriteLine(command);
            return serialPort.ReadLine(); // для SCPI-приладів          

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка обміну: {ex.Message}");
            return null;
        }
    }
    public abstract object ParseResponse(string response);
    public virtual object ParseResponse2(string response) 
    {
        if (string.IsNullOrWhiteSpace(response))
            return double.NaN;

        // Шукаємо перше число в рядку (включаючи експоненційну форму)
        var match = System.Text.RegularExpressions.Regex.Match(
            response,
            @"[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?"
        );
        Console.WriteLine();
        if (match.Success && double.TryParse(match.Value,
            System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture,
            out double value))
        {
            return value;
        }

        // Якщо число не знайшлось – повертаємо оригінальний текст
        return response;
    }
}
