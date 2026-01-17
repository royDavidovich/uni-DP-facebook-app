using System;
using System.Collections.Generic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Facades
{
    /// <summary>
    /// Facade pattern - simplifies access to Facebook services and manages login state
    /// </summary>
    public class FacebookFacade
    {
        private static FacebookFacade s_Instance;
        private static readonly object s_Lock = new object();
        
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;

        private FacebookFacade() { }

        /// <summary>
        /// Singleton instance - ensures one Facebook session throughout the app
        /// </summary>
        public static FacebookFacade Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Lock) // Thread-safe singleton
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new FacebookFacade();
                        }
                    }
                }
                return s_Instance;
            }
        }

        public User LoggedInUser => m_LoggedInUser;
        public string AccessToken => m_LoginResult?.AccessToken;
        public bool IsLoggedIn => m_LoggedInUser != null;

        public LoginResult Login(string appId, params string[] permissions)
        {
            m_LoginResult = FacebookService.Login(appId, permissions);
            
            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
            }

            return m_LoginResult;
        }

        public LoginResult ConnectWithToken(string accessToken)
        {
            m_LoginResult = FacebookService.Connect(accessToken);
            
            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
            }

            return m_LoginResult;
        }

        public void Logout()
        {
            FacebookService.LogoutWithUI();
            m_LoggedInUser = null;
            m_LoginResult = null;
        }

        public List<Post> GetUserPosts()
        {
            var posts = new List<Post>();
            
            if (!IsLoggedIn) return posts;

            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post != null)
                {
                    posts.Add(post);
                }
            }

            return posts;
        }

        public List<Album> GetUserAlbums()
        {
            var albums = new List<Album>();
            
            if (!IsLoggedIn) return albums;

            foreach (Album album in m_LoggedInUser.Albums)
            {
                if (album != null)
                {
                    albums.Add(album);
                }
            }

            return albums;
        }

        public List<Event> GetUserEvents()
        {
            var events = new List<Event>();
            
            if (!IsLoggedIn) return events;

            foreach (Event fbEvent in m_LoggedInUser.Events)
            {
                if (fbEvent != null)
                {
                    events.Add(fbEvent);
                }
            }

            return events;
        }

        public List<Group> GetUserGroups()
        {
            var groups = new List<Group>();
            
            if (!IsLoggedIn) return groups;

            foreach (Group group in m_LoggedInUser.Groups)
            {
                if (group != null)
                {
                    groups.Add(group);
                }
            }

            return groups;
        }

        public List<Page> GetLikedPages()
        {
            var pages = new List<Page>();
            
            if (!IsLoggedIn) return pages;

            foreach (Page page in m_LoggedInUser.LikedPages)
            {
                if (page != null)
                {
                    pages.Add(page);
                }
            }

            return pages;
        }

        public List<Page> GetFavoriteTeams()
        {
            var teams = new List<Page>();
            
            if (!IsLoggedIn) return teams;

            foreach (Page team in m_LoggedInUser.FavofriteTeams)
            {
                if (team != null)
                {
                    teams.Add(team);
                }
            }

            return teams;
        }

        public List<Page> GetMusic()
        {
            var music = new List<Page>();
            
            if (!IsLoggedIn) return music;

            foreach (Page artistPage in m_LoggedInUser.Music)
            {
                if (artistPage != null)
                {
                    music.Add(artistPage);
                }
            }

            return music;
        }

        public string GetUserProfileImageUrl()
        {
            return m_LoggedInUser?.PictureNormalURL;
        }

        public string GetUserName()
        {
            return m_LoggedInUser?.Name ?? "Not logged in";
        }
    }
}