# PageGuideMvc Fluent Wrapper

jQuery.PageGuide ASP.NET Mvc Brought to you by Grasshoppers dev team.

PageGuideMvc is an interactive visual guide to elements on web pages. 
Instead of cluttering your interface with static help message, or explanatory text, 
add a pageguide and let your users learn about new features and functions.

You can dynamically load and unload user guides, fine-tune the positioning of each step, and define event handlers on all parts of the guide (including each step individually) to perform actions in concert with the presentation.

![alt tag](http://rlv.zcache.com.au/funny_kung_fu_grasshopper_stickers-rb51cfd1f1e6240b48b4ddb36ee0fa376_v9waf_8byvr_512.jpg =50x50)

### Version
1.0.0

### Installation
To install PageGuideMvc, run the following command in the Package Manager Console
```sh
Install-Package PageGuideMvc
```
Nuget Link 
[https://www.nuget.org/packages/PageGuideMvc/] 

### Usage
```sh
@(Html.Grasshoppers()
    .PageGuide()
    .SetName("tlyPageGuide2")
    .SetTitle("Wellcome") 
        .NewStep(x => x.Content("Selamlar").Target("#tlyPageGuide").Direction(Direction.Top).CreateStep()) 
        .NewStep(x => x.Content("Hoşçakal").Target(".round").Direction(Direction.Right).CreateStep()) 
        .NewStep(x => x.Content("Heyy nabıyon ?").Target(".two").Direction(Direction.Top).CreateStep()) 
    .Raw() )
```
### Development

Want to contribute? Great!

[Alper Hankendi]:https://github.com/alperhankendi
[Oğuzhan Soykan]:https://github.com/osoykan 

### Todo's
 - multi language supports
 - read steps from view folder
  

License
----

MIT


**Free Software, Hell Yeah!**


