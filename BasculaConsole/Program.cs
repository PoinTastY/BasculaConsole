using System.IO.Ports;
using System.Text;

class Program
{
    static void Main()
    {
        SerialPort serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
        serialPort.Handshake = Handshake.None;
        serialPort.WriteTimeout = 500;
        serialPort.ReadTimeout = 500;

        try
        {
            Console.WriteLine("Abriendo puerto serie...");
            serialPort.Open();

            serialPort.Write("P");

            Thread.Sleep(500);

            // Lee la respuesta de la báscula
            string response = serialPort.ReadExisting();
            Console.WriteLine("Peso recibido: " + response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}