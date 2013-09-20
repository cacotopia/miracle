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
            Console.WriteLine("�ٴ�����˽Կ�ԣ�");  
            RSA.GenneralRSAKey(privateKeyFile, publicKeyFile);  
            publicKey = RSA.ReadPublicKey(publicKeyFile);  
            privateKey = RSA.ReadPrivateKey(privateKeyFile);  
            Console.WriteLine("��Կ��" + publicKey);  
            Console.WriteLine("˽Կ��" + privateKey);  
            string orgStr = "HelloWord";  
            Console.WriteLine("��ʹ�ù�Կ�����ַ�����");  
            string secStr = RSA.RSAEncrypt(publicKey, orgStr);  
            Console.WriteLine(secStr);  
            Console.WriteLine("��ʹ��˽Կ�����ַ�����");  
            Console.WriteLine(SRA.RSA.RSADecrypt(privateKey, secStr));  
  
            Console.Read();  
        }  
    }  
    public class RSA  
    {  
        #region  �����ɹ�˽Կ��  
        /// <summary>  
        /// �����ɹ�˽Կ��  
        /// </summary>  
        /// <param name="PrivateKeyPath">˽Կ�ļ�·��</param>  
        /// <param name="PublicKeyPath">��Կ�ļ�·��</param>  
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
        #region ������Կ�ļ�  
        /// <summary>  
        /// ������Կ�ļ�  
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
        /// ����˽Կ�ļ�  
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
        #region �ڶ�ȡ��Կ  
        /// <summary>  
        /// ��ȡ��Կ  
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
        /// ��ȡ˽Կ  
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
        #region �ۼ��ܽ���  
        /// <summary>  
        /// RSA����  
        /// </summary>  
        /// <param name="xmlPublicKey">��Կ</param>  
        /// <param name="m_strEncryptString">MD5���ܺ������</param>  
        /// <returns>RSA��Կ���ܺ������</returns>  
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
        /// RSA����  
        /// </summary>  
        /// <param name="xmlPrivateKey">˽Կ</param>  
        /// <param name="m_strDecryptString">�����ܵ�����</param>  
        /// <returns>���ܺ�Ľ��</returns>  
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