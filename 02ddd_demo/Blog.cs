using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace _02ddd_demo
{
    public class Blog
    {
        private string name;
        private string content;
        private BlogType blogType;
        private IList<Message> messages;

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public string Content
        {
            get
            {
                return this.content;
            }
        }
        public IList<Message> Messages
        {
            get
            {
                return this.messages;
            }
        }
        public BlogType BlogType
        {
            get
            {
                return this.blogType;
            }
        }
        public void CreateABlog()
        {

        }
        public void ChangeBlogName()
        {

        }
        public void ChangeBlogContent()
        {

        }
        public void AddAMessage()
        { }
        public void RemoveAMessage()
        { }
        public void EditBlogType()
        { }
        public string AAA { get; set; } = "123";
    }
    public class BlogType
    {
        void dosth()
        {
            dynamic o;
            

        }
    }
    public class Message
    { }
}
