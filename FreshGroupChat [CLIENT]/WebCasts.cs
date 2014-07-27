using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

public class WebCasts
{
    public static Image GetImageByUrl(string url, bool redirect = true, bool expect100contiue = true, string referer = "")
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.AllowAutoRedirect = redirect;
        request.Referer = referer;
        request.ServicePoint.Expect100Continue = expect100contiue;
        request.CookieContainer = new CookieContainer();
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.36";
        HttpWebResponse response = null;
        try
        {
            response = (HttpWebResponse)request.GetResponse();
        }
        catch (WebException exception)
        {
            response = (HttpWebResponse)exception.Response;
        }
        return Image.FromStream(response.GetResponseStream());
    }

    public static Image GetImageByUrl_CustomCookies(string url, CookieCollection cookies, bool redirect = true, bool expect100contiue = true, string referer = "")
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.AllowAutoRedirect = redirect;
        request.Referer = referer;
        request.ServicePoint.Expect100Continue = expect100contiue;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.36";
        request.CookieContainer = new CookieContainer();
        foreach (Cookie cookie in cookies)
        {
            request.CookieContainer.Add(cookie);
        }
        HttpWebResponse response = null;
        try
        {
            response = (HttpWebResponse)request.GetResponse();
        }
        catch (WebException exception)
        {
            response = (HttpWebResponse)exception.Response;
        }
        return Image.FromStream(response.GetResponseStream());
    }

    public static HttpWebResponse HttpGet(string url, bool redirect = true, bool expect100contiue = true, string referer = "")
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.Referer = referer;
        request.AllowAutoRedirect = redirect;
        request.ServicePoint.Expect100Continue = expect100contiue;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.168 Safari/535.19";
        request.CookieContainer = new CookieContainer();
        try
        {
            return (HttpWebResponse)request.GetResponse();
        }
        catch (WebException exception)
        {
            return (HttpWebResponse)exception.Response;
        }
    }

    public static HttpWebResponse HttpGet_CustomCookies(string url, CookieCollection cookies, bool redirect = true, bool expect100contiue = true, string referer = "")
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.AllowAutoRedirect = redirect;
        request.Referer = referer;
        request.ServicePoint.Expect100Continue = expect100contiue;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.168 Safari/535.19";
        request.CookieContainer = new CookieContainer();
        foreach (Cookie cookie in cookies)
        {
            request.CookieContainer.Add(cookie);
        }
        try
        {
            return (HttpWebResponse)request.GetResponse();
        }
        catch (WebException exception)
        {
            return (HttpWebResponse)exception.Response;
        }
    }

    public static object[] HttpGet_REQ_AND_RESP_inObject(string url, bool redirect = true, bool expect100contiue = true, string referer = "")
    {
        object[] objArray = new object[2];
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.AllowAutoRedirect = redirect;
        request.Referer = referer;
        request.ServicePoint.Expect100Continue = expect100contiue;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.36";
        request.CookieContainer = new CookieContainer();
        HttpWebResponse response = null;
        try
        {
            response = (HttpWebResponse)request.GetResponse();
        }
        catch (WebException exception)
        {
            response = (HttpWebResponse)exception.Response;
        }
        objArray[0] = request;
        objArray[1] = response;
        return objArray;
    }

    public static object[] HttpGet_REQ_AND_RESP_inObject(string url, CookieCollection cookies, string poststring, bool redirect = true, bool expect100contiue = true, string referer = "")
    {
        object[] objArray = new object[2];
        byte[] bytes = Encoding.UTF8.GetBytes(poststring);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.AllowAutoRedirect = redirect;
        request.Referer = referer;
        request.ServicePoint.Expect100Continue = expect100contiue;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.36";
        request.CookieContainer = new CookieContainer();
        foreach (Cookie cookie in cookies)
        {
            request.CookieContainer.Add(cookie);
        }
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        HttpWebResponse response = null;
        try
        {
            response = (HttpWebResponse)request.GetResponse();
        }
        catch (WebException exception)
        {
            response = (HttpWebResponse)exception.Response;
        }
        objArray[0] = request;
        objArray[1] = response;
        return objArray;
    }

    public static HttpWebResponse HttpPOST(string url, string poststring, bool redirect = true, bool expect100contiue = true, string referer = "")
    {
        byte[] bytes = Encoding.UTF8.GetBytes(poststring);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AllowAutoRedirect = redirect;
        request.Referer = referer;
        request.ServicePoint.Expect100Continue = expect100contiue;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.168 Safari/535.19";
        request.CookieContainer = new CookieContainer();
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        try
        {
            return (HttpWebResponse)request.GetResponse();
        }
        catch (WebException exception)
        {
            return (HttpWebResponse)exception.Response;
        }
    }

    public static HttpWebResponse HttpPOST_CustomCookies(string url, CookieCollection cookies, string poststring, bool redirect = true, bool expect100contiue = true, string referer = "")
    {
        byte[] bytes = Encoding.UTF8.GetBytes(poststring);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ServicePoint.Expect100Continue = expect100contiue;
        request.AllowAutoRedirect = redirect;
        request.Referer = referer;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.3619";
        request.CookieContainer = new CookieContainer();
        foreach (Cookie cookie in cookies)
        {
            request.CookieContainer.Add(cookie);
        }
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        try
        {
            return (HttpWebResponse)request.GetResponse();
        }
        catch (WebException exception)
        {
            return (HttpWebResponse)exception.Response;
        }
    }
}
