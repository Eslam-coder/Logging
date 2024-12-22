namespace DistributedLoggingSystem.Domain
{
    public class LogEntry
    {
        public Guid Id { get; set; }
        
        public string Service { get; set; } = default!;

        public string Level { get; set; } = default!;

        public string Message { get; set; } = default!;

        public DateTime Timestamp { get; set; } = default!;

        public string StorageType { get; set; } = default!;

        private LogEntry()
        {
        }

        private LogEntry(
            string service,
            string level,
            string message,
            DateTime timestamp,
            string storageType)
        {
            UpdateDetails(service, level, message, timestamp, storageType);
        }

        internal void UpdateDetails(
            string service, 
            string level, 
            string message, 
            DateTime timestamp, 
            string storageType)
        {
            ValidateAttributes(service, level);
            Service = service;
            Level = level;
            Message = message;
            Timestamp = timestamp;
            StorageType = storageType;
        }

        private void ValidateAttributes(
            string service, 
            string level)
        {
            if (string.IsNullOrEmpty(service) || string.IsNullOrEmpty(level))
                throw new Exception("Invalid log entry data");
        }

        internal static LogEntry CreateLog(
            string service,
            string level,
            string message,
            DateTime timestamp,
            string storageType)
        {
            return new LogEntry
            (
                service,
                level,
                message,
                timestamp,
                storageType
            );
        }
    }
}
