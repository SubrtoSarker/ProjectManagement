// chart.js
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

        series.appear(1000, 100);
    });
}
