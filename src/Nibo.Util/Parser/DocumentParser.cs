using Microsoft.AspNetCore.Http;
using Nibo.Util.IO;
using Nibo.Util.Parser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Nibo.Util.Parser
{
    public class DocumentParser
    {
        public IEnumerable<TransactionBank> Parse(IFormFile file)
        {
            string data = new Reader().ReadFile(file);

            data = ConvertToXML(data);

            Document document = Deserialize(data);

            AccountRequestInfo accountRequestinfo = document.AccountBankInfoRoot.AccountRequestInfoRoot.AccountRequestInfo;

            AccountData accountData = accountRequestinfo.AccountData;
            List<TransactionInfo> transactionList = accountRequestinfo.BankTransaction.Transactions;

            return transactionList.Select(t => new TransactionBank()
                {
                    BankId = int.Parse(accountData.BankId),
                    Date = t.Date,
                    Type = t.Type,
                    Amount = decimal.Parse(t.Ammount),
                    Memo = t.Memo
                });
        }

        private string ConvertToXML(string data)
        {
            data = data.Remove(0, data.IndexOf("<"));

            using (var reader = new StringReader(data))
            {
                string line;

                var stringBuilder = new StringBuilder();

                while ((line = reader.ReadLine()) != null)
                {
                    var tagEnd = line.IndexOf(">");

                    if (tagEnd != line.Length - 1)
                    {
                        var tagStart = line.IndexOf("<");

                        var tagName = line.Substring(tagStart + 1, (tagEnd - tagStart) - 1);

                        if (line.IndexOf(string.Format("</{0}>", tagName)) > -1)
                        {
                            stringBuilder.AppendLine(line);
                        }
                        else
                        {
                            stringBuilder.AppendLine(String.Concat(line, string.Format("</{0}>", tagName)));
                        }
                    }
                    else
                    {
                        stringBuilder.AppendLine(line);
                    }
                }

                return stringBuilder.ToString();
            }
        }

        private Document Deserialize(string xml)
        {
            var serializer = new XmlSerializer(typeof(Document));

            using (var stringReader = new StringReader(xml))
            using (var xmlTextReader = new XmlTextReader(stringReader))
            {
                return (Document)serializer.Deserialize(xmlTextReader);
            }
        }
    }
}
