# CleanLink

CleanLink is a free and simple app that strips links of their tracking tokens so the data-hungry data farmers have a harder time identifying connections between users.
## Supported Services
- Twitter (just tweets)
- Instagram (Posts, Stories, Reels)
- Reddit (Just posts)
## How to use
### Android
1. Share a text with a link in it, that you want to clean.
2. Upon being offered a choice of the apps to share the link with, pick the CleanLink application
3. Wait until the stripping process is done (should be very short, instantaneous even)
4. The share dialog should appear again, this time pick the application of choice (If the link comes out the same the way it came in and it's service of origin is supposed to be supported, report it in [Issues](https://github.com/h1635149164/CleanLink/issues), or leave a suggestion to add support for that kind of link)
## Installation and supported platforms
So far there's only a functional android build, which can be downloaded as a packaged app from the [Releases](https://github.com/h1635149164/CleanLink/releases) page.
I intend on putting the app up on the F-droid, possibly even Google Play in the future.
## Feedback
I'm open to suggestions and hearing out the issues you might run into while using the app. Suggestions, like possible support for another service's links, 
## Build
To build this project yourself, you'll need Visual Studio with the .NET Multi-platform App UI development package.
## License
This project is licensed under the terms of the [GPLv3](https://www.gnu.org/licenses/gpl-3.0.en.html). See licenses of the used third party libraries and frameworks in [THIRDPARTY.md](https://github.com/h1635149164/CleanLink/blob/master/THIRDPARTY.md)
## Contributing
### Style
- Use tabs to offset items.
- Try to put the opening curly brace on the next line, not the one.
- Try to use camelCase for local variable names
```c#
//Ideal code sample:
if (calledResult)
{
	//Something
}
```
### Other guidelines
- Try to open an Issue to discuss the addition/change you're proposing with others before implementing it.