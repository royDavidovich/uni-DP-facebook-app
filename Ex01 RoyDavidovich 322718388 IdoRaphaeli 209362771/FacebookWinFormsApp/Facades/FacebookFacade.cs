using System;
using System.Collections.Generic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Observers;

namespace BasicFacebookFeatures.Facades
{
    /// <summary>
    /// Facade pattern - simplifies access to Facebook services and manages login state
    /// Also acts as the Subject in the Observer Design Pattern
    /// </summary>
    public class FacebookFacade
    {
        private static FacebookFacade s_Instance;
        private static readonly object sr_Lock = new object();
        
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private readonly List<ILoginObserver> r_Observers = new List<ILoginObserver>();

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
                    lock (sr_Lock) // Thread-safe singleton
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

        // ========== Observer Pattern Implementation ==========

        /// <summary>
        /// Subscribe an observer to login state changes
        /// </summary>
        public void AttachObserver(ILoginObserver i_Observer)
        {
            if (i_Observer == null)
            {
                throw new ArgumentNullException(nameof(i_Observer));
            }

            if (!r_Observers.Contains(i_Observer))
            {
                r_Observers.Add(i_Observer);
            }
        }

        /// <summary>
        /// Unsubscribe an observer from login state changes
        /// </summary>
        public void DetachObserver(ILoginObserver i_Observer)
        {
            if (i_Observer != null)
            {
                r_Observers.Remove(i_Observer);
            }
        }

        /// <summary>
        /// Notify all observers of login state change
        /// Called internally after successful login or logout
        /// </summary>
        private void NotifyObservers()
        {
            foreach (ILoginObserver observer in r_Observers)
            {
                observer.UpdateLoginState(m_LoggedInUser, AccessToken);
            }
        }

        // ========== Facebook Authentication Methods ==========

        public LoginResult Login(string i_AppId, params string[] i_Permissions)
        {
            m_LoginResult = FacebookService.Login(i_AppId, i_Permissions);
            
            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                NotifyObservers();  // Notify observers of successful login
            }

            return m_LoginResult;
        }

        public LoginResult ConnectWithToken(string i_AccessToken)
        {
            m_LoginResult = FacebookService.Connect(i_AccessToken);
            
            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                NotifyObservers();  // Notify observers of successful token connection
            }

            return m_LoginResult;
        }

        public void Logout()
        {
            FacebookService.LogoutWithUI();
            m_LoggedInUser = null;
            m_LoginResult = null;
            NotifyObservers();  // Notify observers of logout
        }

        // ========== Content Retrieval Methods ==========

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