function createDonutChart(data) {
    var chartData = JSON.parse(data);

    am5.ready(function () {
        var root = am5.Root.new("chartdiv");

        root.setThemes([
            am5themes_Animated.new(root)
        ]);

        // Create a container for the chart and legend
        var container = root.container.children.push(am5.Container.new(root, {
            layout: root.horizontalLayout,
            width: am5.percent(100),
            height: am5.percent(100)
        }));

        // Create the chart
        var chart = container.children.push(am5percent.PieChart.new(root, {
            innerRadius: am5.percent(40), // Creates the donut effect
            layout: root.verticalLayout, // Ensures the chart takes up vertical space
            width: am5.percent(80) // Adjust width as needed
        }));

        var series = chart.series.push(am5percent.PieSeries.new(root, {
            name: "Series",
            valueField: "WorkPercent",
            categoryField: "strTaskName"
        }));

        series.data.setAll(chartData);

        // Add tooltips
        series.slices.template.set("tooltipText", "{category}: {value}%");
        series.slices.template.set("tooltipY", 0);
        series.slices.template.set("tooltipX", 0);

        // Add the legend to the right side
        var legend = container.children.push(am5.Legend.new(root, {
            layout: root.verticalLayout,
            position: "right",
            marginLeft: 20 // Space between chart and legend
        }));

        legend.data.setAll(series.dataItems);

        // Ensure the series appears
        series.appear(1000, 100);
    });
}
