$.prototype.chart = function (items, gridOptions, container, barRenderer) {
    var self = this;

    // helper function for elements creation - expect it works fuster, but it looks much better if I use something like this $('<div class="average"></div>')
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
        // so it won't be necessary to allign element vertically 
        bar.css("height", (100 - renderItem.relativeValue) + "%");

        chartBar.append(bar);
        chart.append(chartBar)
    };

    var render_Chart = function (items, gridOptions, container, barRenderer) {

        // data fluctuations can be very small, that is why we need do some calculations to show the chart as something meaningful 
        var minItemValue = Math.min.apply(null, items);
        gridOptions.baseline = minItemValue - minItemValue / 10;

        var getRelativeAmplifiedValue = function (value, gridOptions) {
            // this function calculate drawing size of each bur according to incoming value
            var relVal = value / gridOptions.gridSize;
            var relBaseLine = (gridOptions.baseline / gridOptions.gridSize);

            return 100 * (relVal - relBaseLine) / (1 - relBaseLine);
        }

        var getRenderringItems = function (items, gridOptions) {
            // here we prepare rendering objects which contains real and drawing value
            // and potentially will contatin information about this point such as labels, grid values, notations.
            var result = [];

            items.forEach(function (val) {
                var relative = getRelativeAmplifiedValue(val, gridOptions);
                result.push({ relativeValue: relative, value: val });
            });

            return result;
        }

        renderingItems = getRenderringItems(items, gridOptions);

        var chartContainer = createElement('div', 'chart_container');

        $(container).append(chartContainer);

        renderingItems.forEach(function (val) {
            // render bar 
            barRenderer(chartContainer, val);
        })
    };

    if (!container) {
        container = self;
    }

    if (!barRenderer) {
        barRenderer = defaultBarRenderer;
    }

    // start chart rendering 
    render_Chart(items, gridOptions, container, barRenderer)
};

