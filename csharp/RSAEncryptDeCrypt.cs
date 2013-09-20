using System;  
using System.Collections.Generic;  
using System.Text;  
using System.Security.Cryptography;  
using Microsoft.Win32;  
using System.IO;  
namespace SRA  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            string publicKeyFile = "publicKey.txt";  
            string privateKeyFile = "privateKey.txt";  
            string publicKey = string.Empty;  
            string privateKey = string.Empty;  
            Console.WriteLine("①创建公私钥对：");  
            RSA.GenneralRSAKey(privateKeyFile, publicKeyFile);  
            publicKey = RSA.ReadPublicKey(publicKeyFile);  
            privateKey = RSA.ReadPrivateKey(privateKeyFile);  
            Console.WriteLine("公钥：" + publicKey);  
            Console.WriteLine("私钥：" + privateKey);  
            string orgStr = "HelloWord";  
            Console.WriteLine("②使用公钥加密字符串：");  
            string secStr = RSA.RSAEncrypt(publicKey, orgStr);  
            Console.WriteLine(secStr);  
            Console.WriteLine("③使用私钥解密字符串：");  
            Console.WriteLine(SRA.RSA.RSADecrypt(privateKey, secStr));  
  
            Console.Read();  
        }  
    }  
    public class RSA  
    {  
        #region  ①生成公私钥对  
        /// <summary>  
        /// ①生成公私钥对  
        /// </summary>  
        /// <param name="PrivateKeyPath">私钥文件路径</param>  
        /// <param name="PublicKeyPath">公钥文件路径</param>  
        public static void GenneralRSAKey(string PrivateKeyPath, string PublicKeyPath)  
        {  
            try  
            {  
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();  
                CreatePrivateKeyXML(PrivateKeyPath, provider.ToXmlString(true));  
                CreatePublicKeyXML(PublicKeyPath, provider.ToXmlString(false));  
            }  
            catch (Exception exception)  
            {  
                throw exception;  
            }  
        }  
        #region 创建密钥文件  
        /// <summary>  
        /// 创建公钥文件  
        /// </summary>  
        /// <param name="path"></param>  
        /// <param name="publickey"></param>  
        public static void CreatePublicKeyXML(string path, string publickey)  
        {  
            try  
            {  
                if (File.Exists(path))  
                {  
                    File.Delete(path);  
                }  
                FileStream publickeyxml = new FileStream(path, FileMode.Create);  
                StreamWriter sw = new StreamWriter(publickeyxml);  
                sw.WriteLine(publickey);  
                sw.Close();  
                publickeyxml.Close();  
            }  
            catch  
            {  
                throw;  
            }  
        }  
        /// <summary>  
        /// 创建私钥文件  
        /// </summary>  
        /// <param name="path"></param>  
        /// <param name="privatekey"></param>  
        public static void CreatePrivateKeyXML(string path, string privatekey)  
        {  
            try  
            {  
                if (File.Exists(path))  
                {  
                    File.Delete(path);  
                }  
                FileStream privatekeyxml = new FileStream(path, FileMode.Create);  
                StreamWriter sw = new StreamWriter(privatekeyxml);  
                sw.WriteLine(privatekey);  
                sw.Close();  
                privatekeyxml.Close();  
            }  
            catch  
            {  
                throw;  
            }  
        }  
        #endregion  
        #endregion  
        #region ②读取密钥  
        /// <summary>  
        /// 读取公钥  
        /// </summary>  
        /// <param name="path"></param>  
        /// <returns></returns>  
        public static string ReadPublicKey(string path)  
        {  
            StreamReader reader = new StreamReader(path);  
            string publickey = reader.ReadToEnd();  
            reader.Close();  
            return publickey;  
        }  
        /// <summary>  
        /// 读取私钥  
        /// </summary>  
        /// <param name="path"></param>  
        /// <returns></returns>  
        public static string ReadPrivateKey(string path)  
        {  
            StreamReader reader = new StreamReader(path);  
            string privatekey = reader.ReadToEnd();  
            reader.Close();  
            return privatekey;  
        }  
        #endregion  
        #region ③加密解密  
        /// <summary>  
        /// RSA加密  
        /// </summary>  
        /// <param name="xmlPublicKey">公钥</param>  
        /// <param name="m_strEncryptString">MD5加密后的数据</param>  
        /// <returns>RSA公钥加密后的数据</returns>  
        public static string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)  
        {  
            string str2;  
            try  
            {  
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();  
                provider.FromXmlString(xmlPublicKey);  
                byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);  
                str2 = Convert.ToBase64String(provider.Encrypt(bytes, false));  
            }  
            catch (Exception exception)  
            {  
                throw exception;  
            }  
            return str2;  
        }  
        /// <summary>  
        /// RSA解密  
        /// </summary>  
        /// <param name="xmlPrivateKey">私钥</param>  
        /// <param name="m_strDecryptString">待解密的数据</param>  
        /// <returns>解密后的结果</returns>  
        public static string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)  
        {  
            string str2;  
            try  
            {  
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();  
                provider.FromXmlString(xmlPrivateKey);  
                byte[] rgb = Convert.FromBase64String(m_strDecryptString);  
                byte[] buffer2 = provider.Decrypt(rgb, false);  
                str2 = new UnicodeEncoding().GetString(buffer2);  
            }  
            catch (Exception exception)  
            {  
                throw exception;  
            }  
            return str2;  
        }  
        #endregion    
    }  
}  