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

namespace Bridge.Implementation.OpenEngSB3_0_0.Remote.RemoteObjects
{
    /// <summary>
    /// Container for the Authentification
    /// </summary>
    public class AuthenticationInfo
    {
        #region Variables
        public String className { get; set; }
        public Data data { get; set; }
        #endregion
        #region Public static Methods
        /// <summary>
        /// Creates a new instance of the Authentification
        /// </summary>
        /// <param name="className">ClassName</param>
        /// <param name="data">Data</param>
        /// <param name="binaryData">Binary Data</param>
        /// <returns>A new instance of Authentification</returns>
        public static AuthenticationInfo createInstance(String className, Data data)//, BinaryData binaryData)
        {
            AuthenticationInfo instance = new AuthenticationInfo();
            instance.className = className;
            instance.data = data;
            //instance.binaryData = binaryData;
            return instance;
        }
        #endregion
    }
}
