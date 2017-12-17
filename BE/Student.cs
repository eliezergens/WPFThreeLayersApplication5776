using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BE
{
public class Student //: INotifyDataErrorInfo, IDataErrorInfo
{
    private int id;
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public bool IsMarried { get; set; }
    public DateTime StudentDate { get; set; }
    public Gender StudentGender { get; set; }
    public Campus StudentCampus { get; set; }

        // public string ImageSource  { get; set; }
        //images/pasport/user_8.jpg

        private string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }

        public Student()
        {
            imageSource = (@"Empty Image");

        }
        //    public List<Course> Courses { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }

    }

}
