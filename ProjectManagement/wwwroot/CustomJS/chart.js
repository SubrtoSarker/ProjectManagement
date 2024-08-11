function createDonutChart(data) {
    var chartData = JSON.parse(data);

    am5.ready(function () {
        var root = am5.Root.new("chartdiv");

        root.setThemes([
            am5themes_Animated.new(root)
        ]);

        var chart = root.container.children.push(am5percent.PieChart.new(root, {
            layout: root.verticalLayout
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

        // Add legend and adjust its position
        var legend = chart.children.push(am5.Legend.new(root, {
            position: "bottom",  // Move legend to the bottom
            marginRight: 15,
            marginTop: 15,        // Add some margin for better spacing
            layout: root.horizontalLayout // Layout options: horizontal, vertical
        }));

        legend.data.setAll(series.dataItems);

        series.appear(1000, 100);
    });
}
