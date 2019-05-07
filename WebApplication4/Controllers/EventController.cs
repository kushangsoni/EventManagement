using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EventController : ApiController
    {
        [HttpGet]
        public IList<EventInfo> GetEventInfoes()
        {
            SqlConnection Connection = null;
            try
            {
                Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString);
                Connection.Open();
                var eventinfoes = new List<EventInfo>();

                SqlCommand command = new SqlCommand("Select * from eventinfo", Connection);

                SqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    eventinfoes.Add(
                        new EventInfo()
                        {
                            Id = data.GetInt32(0),
                            EventType = data.GetString(1),
                            EventLevel = data.GetString(2),
                            EventName = data.GetString(3),
                            EventVenue = data.GetString(4),
                            EventDate = data.GetDateTime(5),
                            EventTime = data.GetString(6),
                            EventRegistrationDate = data.GetDateTime(7),
                            EventCoName = data.GetString(8),
                            EventCoNo = data.GetString(9),
                            EventDesc = data.GetString(10)
                        }
                    );
                }
                return eventinfoes;
            }
            catch
            {
                return null;

            }
            finally {
                Connection.Close();
            }
        }
        [HttpGet]
        public EventInfo GetEventInfo(int id) {
            SqlConnection Connection = null;
            try {
                var eventinfoes = new EventInfo();
                Connection = new SqlConnection("Data Source=ODYSOLDEVSQL;Initial Catalog=OdyContent_testDONOTUSEIT;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select  TOP(1) * from eventinfo where Id = @id ", Connection);
                cmd.Parameters.AddWithValue("@id", id);
                Connection.Open();
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    return new EventInfo()
                    {
                        Id = data.GetInt32(0),
                        EventType = data.GetString(1),
                        EventLevel = data.GetString(2),
                        EventName = data.GetString(3),
                        EventVenue = data.GetString(4),
                        EventDate = data.GetDateTime(5),
                        EventTime = data.GetString(6),
                        EventRegistrationDate = data.GetDateTime(7),
                        EventCoName = data.GetString(8),
                        EventCoNo = data.GetString(9),
                        EventDesc = data.GetString(10)
                    };
                }
                else
                {
                    return null;
                }

            }
            catch {

                return null;
            }
            finally {
                Connection.Close();
            }

            
        }
        [HttpPost]
        public void Post(EventInfo eventInfo) {

            SqlConnection Connection = null;
            try
            {
                Connection = new SqlConnection("Data Source=192.168.1.225;Initial Catalog=OdyContent_testDONOTUSEIT;Integrated Security=True ");
                SqlCommand Command = new SqlCommand();
                Connection.Open();
                Command.Connection = Connection;
                Command.CommandText = "insert into eventinfo(EventType,EventLevel,EventName,EventVenue,EventDate,EventTime,EventRegistrationDate,EventCoName,EventCoNo,EventDesc) values(@eventType,@eventLevel,@eventName,@eventVenue,@eventDate,@eventTime,@eventRegDate,@eventCoName,@eventCoNo,@eventDesc)";
                Command.Parameters.AddWithValue("@eventType", eventInfo.EventType);
                Command.Parameters.AddWithValue("@eventLevel", eventInfo.EventLevel);
                Command.Parameters.AddWithValue("@eventName", eventInfo.EventName);
                Command.Parameters.AddWithValue("@eventVenue", eventInfo.EventVenue);
                Command.Parameters.AddWithValue("@eventDate", eventInfo.EventDate);
                Command.Parameters.AddWithValue("@eventTime", eventInfo.EventTime);
                Command.Parameters.AddWithValue("@eventRegDate", eventInfo.EventRegistrationDate);
                Command.Parameters.AddWithValue("@eventCoName", eventInfo.EventCoName);
                Command.Parameters.AddWithValue("@eventCoNo", eventInfo.EventCoNo);
                Command.Parameters.AddWithValue("@eventDesc", eventInfo.EventDesc);
                Command.ExecuteNonQuery();
                Command.Dispose();
                
            }
            catch
            {
                
            }
            finally {
                Connection.Close();
                
            }
            
        }

        [HttpDelete]
        public void Delete(int id)
        {
            SqlConnection Connection =  null;
            try {
                Connection = new SqlConnection("Data Source=192.168.1.225;Initial Catalog=OdyContent_testDONOTUSEIT;Integrated Security=True ");
                SqlCommand Command = new SqlCommand();
                Connection.Open();
                Command.Connection = Connection;
                string UpdateQuery = "delete from eventinfo where Id = @id";
                Command.CommandText = UpdateQuery;
                Command.Parameters.AddWithValue("@id", id);

                Command.ExecuteNonQuery();
                
            }
            catch
            {
                
            }
            finally
            {
                Connection.Close();
            }


            

        }

        [HttpPut]
        public void Put(int id, EventInfo eventInfo) {

            SqlConnection Connection = null;
            try
            {
                Connection = new SqlConnection("Data Source=192.168.1.225;Initial Catalog=OdyContent_testDONOTUSEIT;Integrated Security=True ");
                SqlCommand Command = new SqlCommand();
                Connection.Open();
                Command.Connection = Connection;
                string UpdateQuery = "update eventinfo set EventType = @eventType, EventName = @eventName , EventVenue = @eventVenue , EventDate = @EventDate , EventTime = @eventTime , EventRegistrationDate = @eventRegDate , EventCoName = @eventCoName , EventCoNo = @eventCoNo , EventDesc = @eventDesc where Id = @id";
                Command.CommandText = UpdateQuery;
                Command.Parameters.AddWithValue("@id", eventInfo.Id);
                Command.Parameters.AddWithValue("@eventType", eventInfo.EventType);
                Command.Parameters.AddWithValue("@eventLevel", eventInfo.EventLevel);
                Command.Parameters.AddWithValue("@eventName", eventInfo.EventName);
                Command.Parameters.AddWithValue("@eventVenue", eventInfo.EventVenue);
                Command.Parameters.AddWithValue("@eventDate", eventInfo.EventDate);
                Command.Parameters.AddWithValue("@eventTime", eventInfo.EventTime);
                Command.Parameters.AddWithValue("@eventRegDate", eventInfo.EventRegistrationDate);
                Command.Parameters.AddWithValue("@eventCoName", eventInfo.EventCoName);
                Command.Parameters.AddWithValue("@eventCoNo", eventInfo.EventCoNo);
                Command.Parameters.AddWithValue("@eventDesc", eventInfo.EventDesc);
                Command.ExecuteNonQuery();
                
            }
            catch
            {
                
            }
            finally
            {

            }
        }
    }
}