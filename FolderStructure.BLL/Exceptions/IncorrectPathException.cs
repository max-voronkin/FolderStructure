using System;

namespace FolderStructure.BLL.Exceptions
{
    public class IncorrectPathException : Exception
    {
        public IncorrectPathException(string message) : base(message) { }
        public IncorrectPathException(string message, string nodeId) : base($"{message}, Node id: {nodeId}") { }
    }
}
