using System;
using System.Collections.Generic;
using System.Data;
using DataAccess.DataProvider;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;

        private static readonly object instancelock = new object();

        private MemberDAO() { }

        public static MemberDAO Instace
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public List<MemberObject> MemberList = new List<MemberObject>();

        private MemberObject getAdmin()
        {
            MemberObject admin = null;
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
                string email = config["AdminAccount:Email"];
                string password = config["AdminAccount:Password"];

                admin = new MemberObject
                {
                    MemberId = 0,
                    CompanyName = "F Store",
                    Email = email,
                    Password = password,
                    City = "",
                    Country = ""
                };
                return admin;
            }
        }

        public MemberObject Login(string email, string password)
        {
            MemberObject admin = getAdmin();
            if (admin.Email.Equals(email)
                &&
                admin.Password.Equals(password))
            {
                return admin;
            }
            else
            {
                MemberList = (List<MemberObject>)GetMemberList();
                MemberObject memberLogin = MemberList.SingleOrDefault(member => member.Email.Equals(email) && member.Password.Equals(password));
                return memberLogin;
            }
        }

        public IEnumerable<MemberObject> GetMemberList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select MemberID, Email, CompanyName, City, Country, Password " +
                "From Member";
            var members = new List<MemberObject>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    members.Add(new MemberObject
                    {
                        MemberId = dataReader.GetInt32(0),
                        Email = dataReader.GetString(1),
                        CompanyName = dataReader.GetString(2),
                        City = dataReader.GetString(3),
                        Country = dataReader.GetString(4),
                        Password = dataReader.GetString(5)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return members;
        }
    }
}