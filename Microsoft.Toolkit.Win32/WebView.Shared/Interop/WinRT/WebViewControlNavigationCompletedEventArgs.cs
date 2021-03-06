// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security;
using System.Windows.Forms;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// Provides data for the <see cref="IWebView.NavigationCompleted"/> and <see cref="IWebView.FrameNavigationCompleted"/> events. This class cannot be inherited.
    /// </summary>
    /// <remarks>Copy from <see cref="Windows.Web.UI.WebViewControlNavigationCompletedEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="System.EventArgs" />
    /// <seealso cref="Windows.Web.UI.WebViewControlNavigationCompletedEventArgs"/>
    public sealed class WebViewControlNavigationCompletedEventArgs : EventArgs
    {
        internal WebViewControlNavigationCompletedEventArgs(Windows.Web.UI.WebViewControlNavigationCompletedEventArgs args)
        {
            IsSuccess = args.IsSuccess;
            Uri = args.Uri;
            WebErrorStatus = (WebErrorStatus)args.WebErrorStatus;
        }

        internal WebViewControlNavigationCompletedEventArgs(Windows.Web.UI.WebViewControlNavigationCompletedEventArgs args, Uri uri)
        : this(args)
        {
            Uri = uri;
        }

#if WPF
        internal WebViewControlNavigationCompletedEventArgs(System.Windows.Navigation.NavigationEventArgs e)
        {
            IsSuccess = true; // no ability to detect otherwise
            Uri = e.Uri;
        }
#endif

        internal WebViewControlNavigationCompletedEventArgs(WebBrowserNavigatedEventArgs e)
        {
            IsSuccess = true; // no ability to detect otherwise
            Uri = e.Url;
        }

        /// <summary>
        /// Gets a value indicating whether the navigation completed successfully.
        /// </summary>
        /// <value><see langword="true" /> if the navigation completed successfully; otherwise, <see langword="false" />.</value>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets the Uniform Resource Identifier (URI) of the navigated <see cref="IWebView"/> content.
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri { get; }

        /// <summary>
        /// Gets the reason the navigation was successful.
        /// </summary>
        /// <value>The web error status.</value>
        /// <seealso cref="IsSuccess"/>
        public WebErrorStatus WebErrorStatus { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Windows.Web.UI.WebViewControlNavigationCompletedEventArgs"/> to <see cref="WebViewControlNavigationCompletedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="Windows.Web.UI.WebViewControlNavigationCompletedEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator WebViewControlNavigationCompletedEventArgs(Windows.Web.UI.WebViewControlNavigationCompletedEventArgs args) => ToWebViewControlNavigationCompletedEventArgs(args);

        /// <summary>
        /// Creates a <see cref="WebViewControlNavigationCompletedEventArgs"/> from <see cref="Windows.Web.UI.WebViewControlNavigationCompletedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="Windows.Web.UI.WebViewControlNavigationCompletedEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="WebViewControlNavigationCompletedEventArgs"/></returns>
        public static WebViewControlNavigationCompletedEventArgs ToWebViewControlNavigationCompletedEventArgs(
            Windows.Web.UI.WebViewControlNavigationCompletedEventArgs args) =>
            new WebViewControlNavigationCompletedEventArgs(args);
#if WPF
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Windows.Navigation.NavigationEventArgs"/> to <see cref="WebViewControlNavigationCompletedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="System.Windows.Navigation.NavigationEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator WebViewControlNavigationCompletedEventArgs(System.Windows.Navigation.NavigationEventArgs args) => ToWebViewControlNavigationCompletedEventArgs(args);

        /// <summary>
        /// Creates a <see cref="WebViewControlNavigationCompletedEventArgs"/> from <see cref="System.Windows.Navigation.NavigationEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="System.Windows.Navigation.NavigationEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="WebViewControlNavigationCompletedEventArgs"/>.</returns>
        public static WebViewControlNavigationCompletedEventArgs ToWebViewControlNavigationCompletedEventArgs(
            System.Windows.Navigation.NavigationEventArgs args) =>
            new WebViewControlNavigationCompletedEventArgs(args);
#endif

        /// <summary>
        /// Performs an implicit conversion from <see cref="WebBrowserNavigatedEventArgs"/> to <see cref="WebViewControlNavigationCompletedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="WebBrowserNavigatedEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator WebViewControlNavigationCompletedEventArgs(WebBrowserNavigatedEventArgs args) => ToWebViewControlNavigationCompletedEventArgs(args);

        /// <summary>
        /// Creates a <see cref="WebViewControlNavigationCompletedEventArgs"/> from <see cref="WebBrowserNavigatedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="WebBrowserNavigatedEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="WebViewControlNavigationCompletedEventArgs"/>.</returns>
        public static WebViewControlNavigationCompletedEventArgs ToWebViewControlNavigationCompletedEventArgs(
            WebBrowserNavigatedEventArgs args) =>
            new WebViewControlNavigationCompletedEventArgs(args);
    }
}