﻿/***
 * Licensed to the Austrian Association for Software Tool Integration (AASTI)
 * under one or more contributor license agreements. See the NOTICE file
 * distributed with this work for additional information regarding copyright
 * ownership. The AASTI licenses this file to you under the Apache License,
 * Version 2.0 (the "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
namespace Bridge.Implementation.Communication.Jms
{
    /// <summary>
    /// Send Message
    /// </summary>
    public class JmsOutgoingPort : JmsPort, IOutgoingPort
    {
        #region Variables
        IMessageProducer producer;
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="destination">URL to OpenEngSB</param>
        public JmsOutgoingPort(string destination): base(destination)
        {
            producer = session.CreateProducer(this.destination);
            producer.DeliveryMode = MsgDeliveryMode.Persistent;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Send a string over NMS.
        /// </summary>
        /// <param name="text">Text to send</param>
        /// <param name="receiver">Queue name on server side</param>
        public void Send(string text)
        {
            ITextMessage message = session.CreateTextMessage(text);            
            producer.Send(message);
        }
        /// <summary>
        /// Send a string over NMS and defines the replyTo field
        /// </summary>
        /// <param name="text">Text to send</param>
        /// <param name="replyTo">Reply destination</param>
        public void Send(string text,String queueName)
        {
            ITextMessage message = session.CreateTextMessage(text);            
            message.NMSReplyTo = session.GetQueue(queueName);
            producer.Send(message);
        }

        /// <summary>
        /// Close the Connection
        /// </summary>
        public new void Close()
        {
            base.Close();
            producer.Close();
        }
        #endregion
    }
}
