
// this script renders chart
// by default it will be enough to pass array of values, and grid options 
// example:  $('.chart').chart(last7days.Statistics, { gridSize: 100 });

$.prototype.chart = function (items, gridOptions, container, barRenderer) {
    var self = this;

    // helper function for elements creation - expect it works faster, but it looks much better if I use something like this $('<div class="average"></div>')
    var createElement = function (elmName, className) {
        var elm = $(document.createElement(elmName));
        if (className) {
            elm.addClass(className);
        }
        return elm;
    }

    var defaultBarRenderer = function (chart, renderItem) {
        // this function renders one particular bar in chart
        var chartBar = createElement('div', 'chart_bar');

        var bar = createElement('div', 'chart_bar_content');
        // this element will hide part of bar from up to down 
        // so it won't be necessary to align element vertically 
        bar.css("height", (100 - renderItem.relativeValue) + "%");

        chartBar.append(bar);
        chart.append(chartBar);
    };

    var render_Chart = function (items, gridOptions, container, renderer) {

        // data fluctuations can be very small, that is why we need do some calculations to show the chart as something meaningful 
        var minItemValue = Math.min.apply(null, items);

        // minimum is taken on 1% lesser to make minimum value noticeable on chart
        minItemValue = minItemValue - minItemValue / 100;

        var max = gridOptions.gridSize - minItemValue;

        var getRenderringItems = function (renderingItems) {
            // here we prepare rendering objects which contains real and drawing value
            // and potentially will contain information about this point such as labels, grid values, notations.
            var result = [];

            renderingItems.forEach(function (val) {
                // calculating drawing size in percents of each bur according to incoming value
                // to reflect small fluctuations on chart - the delta is showing 
                var relative = 100 * (val - minItemValue) / max;

                result.push({ relativeValue: relative, value: val });
            });

            return result;
        }

        var renderingItems = getRenderringItems(items, gridOptions);

        var chartContainer = createElement('div', 'chart_container');

        $(container).append(chartContainer);

        renderingItems.forEach(function(val) {
            // render bar 
            renderer(chartContainer, val);
        });
    };

    if (!container) {
        container = self;
    }

    if (!barRenderer) {
        barRenderer = defaultBarRenderer;
    }

    // start chart rendering 
    render_Chart(items, gridOptions, container, barRenderer);
};

