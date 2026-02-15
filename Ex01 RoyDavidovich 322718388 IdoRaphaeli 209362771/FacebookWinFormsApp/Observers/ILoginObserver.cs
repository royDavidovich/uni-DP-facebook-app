    using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Observers
{
    /// <summary>
    /// Observer interface for listening to login state changes
    /// Implements the Observer Design Pattern
    /// </summary>
    public interface ILoginObserver
    {
        /// <summary>
        /// Called when the login state changes
        /// </summary>
        /// <param name="i_LoggedInUser">The logged-in user, or null if logged out</param>
        /// <param name="i_AccessToken">The access token, or null if logged out</param>
        void UpdateLoginState(User i_LoggedInUser, string i_AccessToken);
    }
}