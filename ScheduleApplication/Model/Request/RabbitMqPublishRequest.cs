using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApplication.Model.Request;

public class RabbitMqPublishRequest<T>
{
    public string ExchangeName { get; set; }
    public string RoutingKey { get; set; }
    public List<string> MessageType { get; set; }
    public T Message { get; set; }
}

