using System;
using System.IO;
using System.Threading;
using System.Web.Script.Serialization;

namespace MusicHotkeys
{
    public class NativeMessaging
    {
        public class JsonCommand
        {
            public JsonCommand() { }
            public JsonCommand(string action, string data)
            {
                this.action = action;
                this.data = data;
            }

            public string action { get; set; }
            public string data { get; set; }
        }

        public string TrackName = null;
        public string PressedKey = null;

        public NativeMessaging()
        {
            new Thread(new ThreadStart(this.ProcessRead)).Start();
            new Thread(new ThreadStart(this.ProcessWrite)).Start();
        }

        private void ProcessRead()
        {
            while (true)
            {
                JsonCommand cmd = ReadCommand();
                if (cmd != null)
                {
                    switch (cmd.action)
                    {
                        case "update_name":
                            TrackName = cmd.data;
                            break;
                    }
                }
                Thread.Sleep(250);
            }
        }

        private void ProcessWrite()
        {
            while (true)
            {
                if (PressedKey != null)
                {
                    string key = PressedKey;
                    PressedKey = null;
                    WriteCommand(new JsonCommand("press_key", key));
                }
                Thread.Sleep(250);
            }
        }

        private static JsonCommand ReadCommand()
        {
            try
            {
                //First 4 bytes is length
                Stream stdin = Console.OpenStandardInput();
                int length = 0;
                byte[] bytes = new byte[4];
                stdin.Read(bytes, 0, 4);
                length = System.BitConverter.ToInt32(bytes, 0);
                string json = "";
                for (int i = 0; i < length; i++)
                    json += (char)stdin.ReadByte();
                if (!string.IsNullOrEmpty(json))
                    return new JavaScriptSerializer().Deserialize<JsonCommand>(json);
            }
            catch { }
            return null;
        }

        private static void WriteCommand(JsonCommand cmd)
        {
            try
            {
                string json = new JavaScriptSerializer().Serialize(cmd);
                //First 4 bytes is length
                int DataLength = json.Length;
                Stream stdout = Console.OpenStandardOutput();
                stdout.WriteByte((byte)((DataLength >> 0) & 0xFF));
                stdout.WriteByte((byte)((DataLength >> 8) & 0xFF));
                stdout.WriteByte((byte)((DataLength >> 16) & 0xFF));
                stdout.WriteByte((byte)((DataLength >> 24) & 0xFF));
                Console.Write(json);
            }
            catch { }
        }
    }
}
