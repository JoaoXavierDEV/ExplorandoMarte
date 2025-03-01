using ExplorandoMarte.Interfaces;
using System;
using System.IO;
using System.Text;

namespace ExplorandoMarte.Models
{
    public class Logger : ILogger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private readonly string _logFilePath;

        private Logger()
        {
            // Define o caminho do arquivo de log
            string logDirectory = @"C:\ExplorandoMarte\logs";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory); // Cria o diretório se ele não existir
            }
            _logFilePath = Path.Combine(logDirectory, "log.txt");
        }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        public void LogError(string message)
        {
            var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {message}";
            WriteLog(logMessage);
        }

        public void LogMessage(string message)
        {
            WriteLog(message);
        }

        private void WriteLog(string message)
        {
            // Adiciona mensagem de log ao arquivo, codificação UTF-8
            File.AppendAllText(_logFilePath, message + Environment.NewLine, Encoding.UTF8);
        }
    }
}