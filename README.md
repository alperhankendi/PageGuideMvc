# PageGuideMvc
PageGuideMvc


Usage:

@(Html.Grasshoppers().PageGuide().SetName("tlyPageGuide2").SetTitle("Sayfa Gezginine Hoşgeldiniz!!!.")
            .NewStep(x => x.Content("Selamlar").Target("#tlyPageGuide").Direction(Direction.Top).CreateStep())
            .NewStep(x => x.Content("Hoşçakal").Target(".round").Direction(Direction.Right).CreateStep())
            .NewStep(x => x.Content("Heyy nabıyon ?").Target(".two").Direction(Direction.Top).CreateStep())
            .Raw()
)
22:27
