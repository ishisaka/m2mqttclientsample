// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Tadahiro Ishisaka">
//   Copyright 2014 Tadahiro Ishisaka
// </copyright>
// <license>
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </license>
// <summary>
//   MQTT Publishのサンプル
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CsPubClient
{
    using System;
    using System.Text;

    using uPLibrary.Networking.M2Mqtt;

    /// <summary>MQTT Publishのサンプル</summary>
    internal class Program
    {
        #region Methods

        /// <summary>MQTT Publishのサンプル.</summary>
        /// <param name="args">コマンドライン引数</param>
        private static void Main(string[] args)
        {
            var client = new MqttClient("test.mosquitto.org");

            var ret = client.Connect(Guid.NewGuid().ToString());
            Console.WriteLine("Connected with result code {0}", ret);

            while (client.IsConnected)
            {
                var msg = "Test message from Publisher " + DateTime.Now;
                client.Publish("test", Encoding.UTF8.GetBytes(msg), 0, true);
                Console.WriteLine("Message published.");
                System.Threading.Thread.Sleep(1500);
            }
        }

        #endregion
    }
}