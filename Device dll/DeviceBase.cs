using System;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

public abstract class DeviceBase
{
    protected int BaudRate;
    protected int DataBits;
    protected Parity Parity;
    protected StopBits StopBits;
    protected string Terminator;
    protected Handshake Handshake;
    protected int Timeout;
    protected string IndificateName;
    protected DeviceBase(
        int baudRate,
        int dataBits,
        Parity parity,
        StopBits stopBits,
        string terminator,
        Handshake handshake,
        int timeout,
        string IndificateName)
    {
        Terminator = terminator;
        Handshake = handshake;
        BaudRate = baudRate;
        Parity = parity;
        DataBits = dataBits;
        StopBits = stopBits;
        Timeout = timeout;
    }
    protected SerialPort serialPort;

    public bool IsConnected => serialPort != null && serialPort.IsOpen;
    
    public virtual bool Connect(string portName)
    {
        try
        {
            serialPort = new SerialPort(portName, BaudRate, Parity, DataBits, StopBits)
            {
                Handshake = Handshake,
                ReadTimeout = Timeout,
                WriteTimeout = Timeout,
                NewLine = Terminator
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
    public bool ConnectAndCheck(string portName)
    {
        try
        {
            serialPort = new SerialPort(portName, BaudRate, Parity, DataBits, StopBits)
            {
                Handshake = Handshake,
                ReadTimeout = Timeout,
                WriteTimeout = Timeout,
                NewLine = Terminator
            };
            serialPort.Open();
            string response = SendCommand("*IDN?",100);            

            if (response.Contains(IndificateName))
                return true;
            else 
            {

                Disconnect();
                return false;
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
    public virtual string SendCommand(string command, int waitMs = 50)
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
