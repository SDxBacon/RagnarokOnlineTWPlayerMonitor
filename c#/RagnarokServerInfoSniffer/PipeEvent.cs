using System.Text.Json;

namespace PipeEvent
{
    public enum OutputEventTypes : int
    {
        [StringValue("o_network_interfaces")]
        NetworkInterfaces = 0x00,
    }

    public enum InputEventTypes : int
    {
        [StringValue("i_get_network_interfaces")]
        GetNetworkInterfaces = 0x90,
    }

    public class PipeEvent
    {
        public int type;
    }

    public class PipeEventHelper
    {
        public static bool IsPipeEvent(string raw_iput)
        {
            try
            {
                var value = JsonSerializer.Deserialize<PipeEvent>(raw_iput);
                Console.WriteLine(raw_iput);
                if (value == null) return false;
                Console.WriteLine(typeof(value.type));
                Console.WriteLine((Enum.IsDefined(typeof(InputEventTypes), value.type)));
                Console.WriteLine((Enum.IsDefined(typeof(OutputEventTypes), value.type)));

                if (Enum.IsDefined(typeof(InputEventTypes), value.type)
                    || Enum.IsDefined(typeof(OutputEventTypes), value.type))
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }

        }
    }


    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// </summary>
    public class StringValueAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion

    }
}