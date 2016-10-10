using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace GCNI
{
    public class PublicationClass
    {
        #region used Variables
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string pubthumbImage;
        string pubFile;
        string imgURL;
        string fileURL;
        string VideoURL;
        #endregion

        public int SaveAndUpdate(string Title, string Description, string ThumbnailImage, string File, bool IsDisplayOnHome ,string Qtype)
        {
            cmd = new SqlCommand("spPublication", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@ThumbnailURL", ThumbnailImage);
            cmd.Parameters.AddWithValue("@FileURL", File);
            cmd.Parameters.AddWithValue("@IsDisplayOnHome", IsDisplayOnHome);
            cmd.Parameters.AddWithValue("@Qtype", Qtype);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            return res;

        }
    }
}