using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1
{
    public partial class MainForm : Form
    {
        private readonly NewsFeedManager _newsManager;
        private object pnNews;

        public MainForm(NewsFeedManager newsManager)
        {
            _newsManager = newsManager;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowFeedOnTreeView(_newsManager.GetNewsFeed());
        }

        private void ShowFeedOnTreeView(List<Models.Publisher> publishers)
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddFeedForm(_newsManager))
            {
                dialog.ShowDialog(this);

                if (dialog.HasChanges)
                {
                    _newsManager.SaveChanges();
                    ShowFeedOnTreeView(_newsManager.GetNewsFeed());
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void tvwPublisher_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void ShowFeedOnTreeView(List<Publisher> publishers)
        {
            tvwPublisher.Nodes.Clear();
            panel1.Controls.Clear();

            foreach (var publisher in publishers)
            {
                var publisherNode = tvwPublisher.Nodes.Add(publisher.Name);

                foreach (var category in publisher.Categories)
                {
                    publisherNode.Nodes.Add(category.Name);
                }
            }

            tvwPublisher.ExpandAll();
        }
    }
}
