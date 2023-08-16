using System.Text.Json;
using WebSocketApi.Events.Interfaces;
using WebSocketApi.Events.Types;

namespace WebSocketApi.Events.Interfaces
{
    public interface IEventFactory
    {
        void ExecuteEvent(string jsonString);
    }

    public abstract class EventFactoryBase<TInput> : IEventFactory
    {
        private TInput ValidateInput(string jsonString)
        {
            var input = JsonSerializer.Deserialize<TInput>(jsonString);

            if (input == null)
            {
                throw new JsonException("JSON null");
            }

            return input;
        }

        public void ExecuteEvent(string jsonString)
        {
            try
            {
                var input = ValidateInput(jsonString);
                if (input != null)
                {
                    this.Execute(input);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Input inválido!");
            }
        }

        public abstract void Execute(TInput input);
    }
}