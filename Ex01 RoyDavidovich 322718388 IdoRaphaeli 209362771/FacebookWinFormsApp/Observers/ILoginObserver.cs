    using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Observers
{
    /// Observer interface for listening to login state changes
    /// Implements the Observer Design Pattern

    public interface ILoginObserver
    {   
        void UpdateLoginState(User i_LoggedInUser, string i_AccessToken);
    }
}