using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAdvisor
{
        class Cryptography
        {
            public static string EncryptData(string dataEncrypt)
            {
                byte[] data = ASCIIEncoding.ASCII.GetBytes(dataEncrypt);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                string hashDataResult = Encoding.ASCII.GetString(data);

                return hashDataResult;
            }

        }
}


