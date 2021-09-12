using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1
{
    public partial class AddFeedForm : Form
    {
        private readonly NewsFeedManager _newsManager;
        private NewsFeedManager newsManager;
        private IEnumerable<object> publishers;
        private object cbbPublishers;

        public bool HasChanges { get; set; }
        public AddFeedForm(NewsFeedManager _newsManager)
        {
            _newsManager = newsManager;
            InitializeComponent();


        }

        private void AddFeedForm_Load(object sender, EventArgs e)
        {
            var publisher = _newsManager.GetNewsFeed();
            foreach (var publisher in publishers)
            {
                cbbPublishers.Items.Add(publisher.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var publisherName = cbbPublishers.Text;
            var categoryName = txtCategoryName.text;
            var rssLink = txtRssLink.Text;

            if (string.IsNullOrWhiteSpace(publisherName) ||
                    string.IsNullOrWhiteSpace(categoryName) ||
                string.IsNullOrWhiteSpace(rssLink))
            {
                MessageBox.Show("bạn phải nhập đầy đủ dữ liệu", "Lỗi");
                return;
            }

            HasChanges = true;

            var success = _newsManager.AddCategory(publisherName, categoryName, rssLink, false);
            if (success)
            {
                ClearForm();
                return;
            }

            if (MessageBox.Show("Chuyên mục này đã tồn tại, bạn có muốn cập nhật RSS Link không?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
            {
                _newsManager.AddCategory(publisherName, categoryName, rssLink, true);
            }

            ClearForm();


  




        }
        private void ClearForm()
        {
            cbbPublishers.Text = "";
            txtCategoryName.Text = "";
            txtRssLink.Text = "";
        }
    }
}
