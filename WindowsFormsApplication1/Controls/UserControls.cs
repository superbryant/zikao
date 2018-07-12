using Dal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1.Controls
{
    class UserControls
    {
        public UserControls()
        {

        }

        public void DoWork()
        {
            int userId = 1194493;
            List<Models.Root> users = new List<Models.Root>();
            List<Users> models = new List<Users>();

            for (int i = 1194492; i > 0; i--)
            {
                try
                {
                    PostUserJson post = new PostUserJson()
                            {
                                osVersion = "PC",
                                appVersion = "2.0.1",
                                userId = ( i).ToString()
                            };
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(post);
                    string URI = "http://luntan.sunlands.com/community-pc-war/user/getPersonDetailByUserId.action";
                    var response = PostJson(URI, json);
                    var responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Root>(response);
                    if (responseJson.rs == 1)

                        models.Add(new Users()
                        {
                            isVip = responseJson.resultMessage.isVip.ToString(),
                            mobile = responseJson.resultMessage.mobile,
                            nickname = responseJson.resultMessage.nickname,
                            sex = responseJson.resultMessage.sex,
                            signature = responseJson.resultMessage.signature,
                            UserId = responseJson.resultMessage.id.ToString(),
                            userMarkList = string.Join(",", responseJson.resultMessage.userMarkList),
                            username = responseJson.resultMessage.username,
                             CreateDate=DateTime.Now,
                        });
                    if (models.Count >= 1000)
                    {
                        using (SqlConnection cnt = new SqlConnection("Data Source=.;Initial Catalog=ZiKao;Integrated Security=True;MultipleActiveResultSets=True;"))
                        {
                            cnt.BulkCopy(models, models.Count);
                        }
                        models = new List<Users>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            using (SqlConnection cnt = new SqlConnection("Data Source=.;Initial Catalog=ZiKao;Integrated Security=True;MultipleActiveResultSets=True;"))
            {
                cnt.BulkCopy(models, models.Count);
            }
        }

        public static string PostJson(string url, string data)
        {
            var bytes = Encoding.UTF8.GetBytes("data=" + data);

            using (var client = new WebClient())
            {



                client.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

                //                Accept: application/json, text/javascript, */*; q=0.01
                //Accept-Encoding: gzip, deflate
                //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8
                //Connection: keep-alive
                //Content-Length: 193
                //Content-Type: multipart/form-data; boundary=---------------------------163a1c5db2c
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //client.Headers.Add(HttpRequestHeader.ContentLength, bytes.Length.ToString());
                //Cookie: JSESSIONID=F48FF098CAD3C0B6E531AEE090744A38; userIdentify=7ee4e929-17a2-4185-9cae-7340607523c6; Hm_lvt_fcf2048c0a9ed8c99bf6e08cf074b278=1524664055; Hm_lvt_3b92ef8db1054c41ec24e09ecd765369=1525696922; Hm_lvt_042f1b4fd18a22ee217f0673c4c1b92f=1527074591,1527248652,1527422410,1527426266; Hm_lpvt_042f1b4fd18a22ee217f0673c4c1b92f=1527427259
                //Host: luntan.sunlands.com
                client.Headers.Add("Host", "luntan.sunlands.com");
                //Origin: http://luntan.sunlands.com
                client.Headers.Add("Origin", " http://luntan.sunlands.com");
                //Referer: http://luntan.sunlands.com/community-pc-war/
                client.Headers.Add("Referer", "http://luntan.sunlands.com/community-pc-war/");
                //User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36");
                //X-Requested-With: XMLHttpRequest
                //User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36
                //X-Requested-With: XMLHttpRequest
                //-----------------------------163a1c5db2c
                //Content-Disposition: form-data; name="data"

                //{"userId":"1000000","appVersion":"2.0.1","osVersion":"PC"}
                //-----------------------------163a1c5db2c--
                var response = client.UploadData(url, "POST", bytes);

                var s = Encoding.UTF8.GetString(response);
                //Console.WriteLine(s);
                return s;
            }
        }


    }
}
