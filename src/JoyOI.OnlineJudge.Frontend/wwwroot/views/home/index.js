﻿app.title = '首页';
app.links = [];

component.data = function () {
    return {
        contests: [],
        threads: []
    }
}

component.created = function () {
    this.loadContests();
    this.loadThreads();
}

component.methods = {
    loadThreads: function () {
        var self = this;
        qv.createView('/api/forum/summary', null, 60000)
            .fetch(x => {
                self.threads = x.data;
            })
            .catch(err => {
                app.notification('error', '获取论坛帖子失败', err.responseJSON.msg);
            });
    },
    loadContests: function () {
        var self = this;
        qv.createView('/api/contest/all', {}, 60000)
            .fetch(x => {
                var results = clone(x.data.result);
                results = results.map(y => {
                    var begin = new Date(y.begin);
                    var end = new Date(begin.getTime() + parseTimeSpan(y.duration))
                    if (new Date() < begin) {
                        y.status = 'Ready';
                        y.statusClass = 'contest-ready';
                    } else if (new Date() < end) {
                        y.status = 'Live';
                        y.statusClass = 'contest-live';
                    } else {
                        y.status = 'Done';
                        y.statusClass = 'contest-done';
                    }
                    return y;
                });
                self.contests = results;
            })
            .catch(err => {
                app.notification('error', '获取比赛失败', err.responseJSON.msg);
            });
    }
};