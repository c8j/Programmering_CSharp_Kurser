namespace Westcoast_shop.Models;

public static class Database
{
    public static bool FindProduct(int id, out string name, out decimal price)
    {
        if (id == 1)
        {
            name = "Kofot";
            price = 149M;
        }
        else if (id == 2)
        {
            name = "Slägga";
            price = 1095M;
        }
        else
        {
            throw new ArgumentException($"Kunde inte hitta produkt med ID: {id}");
        }
        return true;
    }

    public static ContactDetails FindContactDetails(int customerNumber)
    {
        if (customerNumber == 0)
        {
            return new ContactDetails()
            {
                Name = "Vanhedens järnhandel",
                Address = new()
                {
                    Street = "Stålgatan",
                    Number = "14",
                    PostalCode = "888 98",
                    City = "Hålan",
                },
                Phone = "073-444222",
                Reference = "Dynamit Harry",
                ReferenceEmail = "harry@gmail.com",
            };
        }
        else if (customerNumber == 981256)
        {
            return new ContactDetails()
            {
                Name = "Bosse Kofot",
                Address = new()
                {
                    Street = "Rånarvägen",
                    Number = "1",
                    PostalCode = "666 78",
                    City = "Härlanda",
                },
                Reference = "Sickan Karlsson",
            };
        }
        else
        {
            throw new ArgumentException($"Kunde inte hitta kontaktinformation för kundnummer: {customerNumber}");
        }
    }

    public static int FindPaymentTerms(int customerNumber)
    {
        if (customerNumber == 981256)
        {
            return 30;
        }
        else
        {
            throw new ArgumentException($"Kunde inte hitta betalningsvilkor för kund med nummer: {customerNumber}");
        }
    }
}
