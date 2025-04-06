using System;
using System.Collections.Generic;

namespace Visitor.Example
{
    interface IVisitor
    {
        void VisitPersonAccount(PersonAccount personAccount);
        void VisitCompanyAccount(CompanyAccount companyAccount);
    }
    // Сериализатор в HTML.
    class HtmlVisitor : IVisitor
    {
        public void VisitPersonAccount(PersonAccount personAccount)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>\n" +
                $"<tr><td>Name<td><td>{personAccount.Name}</td></tr>\n" +
                $"<tr><td>Number<td><td>{personAccount.Number}</td></tr></table>\n";
            Console.WriteLine(result);
        }
        public void VisitCompanyAccount(CompanyAccount companyAccount)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>\n" +
                $"<tr><td>Name<td><td>{companyAccount.Name}</td></tr>\n" +
                $"<tr><td>RegNumber<td><td>{companyAccount.RegNumber}</td></tr>\n" +
                $"<tr><td>Number<td><td>{companyAccount.Number}</td></tr></table>\n";
            Console.WriteLine(result);
        }
    }
    // Сериализатор в XML.
    class XmlVisitor : IVisitor
    {
        public void VisitPersonAccount(PersonAccount account)
        {
            string result = $"<Person><Name>{account.Name}</Name>\n" +
                $"<Number>{account.Number}</Number><Person>\n";
            Console.WriteLine(result);
        }
        public void VisitCompanyAccount(CompanyAccount account)
        {
            string result = $"<Company><Name>{account.Name}</Name>\n" +
                $"<RegNumber>{account.RegNumber}</RegNumber>\n" +
                $"<Number>{account.Number}</Number><Company>\n";
            Console.WriteLine(result);
        }
    }

    // Element.
    interface IAccount
    {
        void Accept(IVisitor visitor);
    }
    class PersonAccount : IAccount
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public void Accept(IVisitor visitor) => visitor.VisitPersonAccount(this);
    }
    class CompanyAccount : IAccount
    {
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string Number { get; set; }

        public void Accept(IVisitor visitor) => visitor.VisitCompanyAccount(this);
    }

    // ObjectStructure.
    class Bank
    {
        List<IAccount> Accounts = new List<IAccount>();

        public void Add(IAccount account) => Accounts.Add(account);
        public void Remove(IAccount account) => Accounts.Remove(account);
        public void Accept(IVisitor visitor)
        {
            foreach (IAccount account in Accounts)
                account.Accept(visitor);
        }
    }
}
