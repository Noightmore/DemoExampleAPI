const path = require('path');
module.exports = {
    entry: './src/index',
    devtool: 'inline-source-map',
    module: {
        rules: [{
            test: /\.tsx?$/,
            use: ['ts-loader', 'css-loader'],
            exclude: /node_modules/
        }]
    },
    resolve: {
        extensions: ['.ts', '.js', '.tsx', '.css']
    },
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'dist')
    }
};