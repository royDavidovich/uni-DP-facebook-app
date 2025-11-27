using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Logics;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicFacebookFeatures
{
    public partial class chartActivity : UserControl
    {
        private User m_LoggedInUser;

        public chartActivity()
        {
            InitializeComponent();
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_LoggedInUser == null)
            {
                MessageBox.Show("Please login first.");
                return;
            }

            List<ActivityPoint> points;
            string mode;
            string title;

            switch (comboBoxTime.SelectedIndex)
            {
                case 0:
                    points = getActivityLastMonth();
                    mode = "Month";
                    title = "Post Activity – last month";
                    break;

                case 1:
                    points = getActivityLastYear();
                    mode = "Year";
                    title = "Post Activity – last year";
                    break;

                case 2:
                default:
                    points = getActivityFromBeginning();
                    mode = "AllYears";
                    title = "Post Activity – since account created";
                    break;
            }

            displayActivity(points, title, mode);
        }

        public void SetLoggedInUser(User i_LoggedInUser)
        {
            m_LoggedInUser = i_LoggedInUser;

            if (comboBoxTime.Items.Count > 0)
            {
                comboBoxTime.SelectedIndex = 0;
            }
        }

        private void displayActivity(List<ActivityPoint> i_Points, string i_Title, string i_Mode)
        {
            chartActivity1.Series.Clear();
            chartActivity1.ChartAreas.Clear();
            chartActivity1.Titles.Clear();

            ChartArea area = new ChartArea("MainArea");
            chartActivity1.ChartAreas.Add(area);

            Series series = new Series("Post Activity");
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.String;
            series.YValueType = ChartValueType.Int32;

            foreach (ActivityPoint point in i_Points)
            {
                string label;

                if (i_Mode == "Month")
                {
                    label = point.Date.ToString("dd/MM");
                }
                else if (i_Mode == "Year")
                {
                    label = point.Date.ToString("MM/yyyy");
                }
                else // Since beginning
                {
                    label = point.Date.Year.ToString();
                }

                series.Points.AddXY(label, point.Count);
            }

            chartActivity1.Series.Add(series);
            chartActivity1.Titles.Add(i_Title);
        }

        private List<ActivityPoint> getActivityLastMonth()
        {
            List<ActivityPoint> points = new List<ActivityPoint>();

            if (m_LoggedInUser == null)
            {
                return points;
            }

            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddMonths(-1);

            Dictionary<DateTime, int> postsPerDay = new Dictionary<DateTime, int>();

            foreach (Post post in fetchAllPosts())
            {
                DateTime postDate = post.CreatedTime.Value.Date;

                if (postDate < startDate || postDate > endDate)
                {
                    continue;
                }

                if (!postsPerDay.ContainsKey(postDate))
                {
                    postsPerDay[postDate] = 0;
                }

                postsPerDay[postDate]++;
            }

            DateTime current = startDate;

            while (current <= endDate)
            {
                int count = 0;
                if (postsPerDay.ContainsKey(current))
                {
                    count = postsPerDay[current];
                }

                points.Add(new ActivityPoint
                {
                    Date = current,
                    Count = count
                });

                current = current.AddDays(1);
            }

            return points;
        }

        private List<ActivityPoint> getActivityLastYear()
        {
            List<ActivityPoint> points = new List<ActivityPoint>();

            if (m_LoggedInUser == null)
            {
                return points;
            }

            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddYears(-1);

            Dictionary<DateTime, int> postsPerMonth = new Dictionary<DateTime, int>();

            foreach (Post post in fetchAllPosts())
            {
                DateTime postDate = post.CreatedTime.Value.Date;

                if (postDate < startDate || postDate > endDate)
                {
                    continue;
                }

                DateTime monthKey = new DateTime(postDate.Year, postDate.Month, 1);

                if (!postsPerMonth.ContainsKey(monthKey))
                {
                    postsPerMonth[monthKey] = 0;
                }

                postsPerMonth[monthKey]++;
            }

            DateTime current = new DateTime(startDate.Year, startDate.Month, 1);
            DateTime lastMonth = new DateTime(endDate.Year, endDate.Month, 1);

            while (current <= lastMonth)
            {
                int count = 0;
                if (postsPerMonth.ContainsKey(current))
                {
                    count = postsPerMonth[current];
                }

                points.Add(new ActivityPoint
                {
                    Date = current,
                    Count = count
                });

                current = current.AddMonths(1);
            }

            return points;
        }

        private List<ActivityPoint> getActivityFromBeginning()
        {
            List<ActivityPoint> points = new List<ActivityPoint>();
            List<Post> allPosts = fetchAllPosts();

            if (allPosts.Count == 0)
            {
                return points;
            }

            int firstYear = allPosts[0].CreatedTime.Value.Year;
            int lastYear = allPosts[0].CreatedTime.Value.Year;

            foreach (Post post in allPosts)
            {
                int year = post.CreatedTime.Value.Year;

                if (year < firstYear)
                {
                    firstYear = year;
                }

                if (year > lastYear)
                {
                    lastYear = year;
                }
            }

            Dictionary<int, int> postsPerYear = new Dictionary<int, int>();

            foreach (Post post in allPosts)
            {
                int year = post.CreatedTime.Value.Year;

                if (!postsPerYear.ContainsKey(year))
                {
                    postsPerYear[year] = 0;
                }

                postsPerYear[year]++;
            }

            for (int year = firstYear; year <= lastYear; year++)
            {
                int count = 0;
                if (postsPerYear.ContainsKey(year))
                {
                    count = postsPerYear[year];
                }

                points.Add(new ActivityPoint
                {
                    Date = new DateTime(year, 1, 1),
                    Count = count
                });
            }

            return points;
        }

        private List<Post> fetchAllPosts()
        {
            List<Post> allPosts = new List<Post>();

            if (m_LoggedInUser == null)
            {
                return allPosts;
            }

            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post != null && post.CreatedTime.HasValue)
                {
                    allPosts.Add(post);
                }
            }

            return allPosts;
        }

        private void chartActivity_Resize(object sender, EventArgs e)
        {
            comboBoxTime.Left = (int)((this.ClientSize.Width - comboBoxTime.Width) * 0.1);
            comboBoxTime.Top = (int)((this.ClientSize.Height - comboBoxTime.Height) / 2);

            chartActivity1.Left = (int)(comboBoxTime.Left + comboBoxTime.Width*1.5);
            chartActivity1.Top = (int)(labelActivity.Top + labelActivity.Height * 1.5);
            chartActivity1.Height = (int)(this.ClientSize.Height * 0.5);
            chartActivity1.Width = (int)(this.ClientSize.Width * 0.5);
        }
    }
}
