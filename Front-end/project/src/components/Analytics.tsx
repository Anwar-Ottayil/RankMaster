import React, { useState } from 'react';
import { TrendingUp, Users, BookOpen, Target, Calendar, Download, Filter } from 'lucide-react';

const Analytics: React.FC = () => {
  const [timeframe, setTimeframe] = useState('7d');
  const [metric, setMetric] = useState('all');

  const analyticsData = {
    overview: {
      totalUsers: { value: 12847, change: '+12%', trend: 'up' },
      activeExams: { value: 156, change: '+8%', trend: 'up' },
      examParticipation: { value: 8924, change: '+15%', trend: 'up' },
      avgScore: { value: 72.5, change: '+3%', trend: 'up' }
    },
    examStats: [
      { name: 'JEE Main Mock Test #45', participants: 1247, avgScore: 68.2, completion: 94 },
      { name: 'NEET Biology Practice', participants: 856, avgScore: 75.8, completion: 87 },
      { name: 'Class 10 Mathematics', participants: 534, avgScore: 81.2, completion: 92 },
      { name: 'Degree Physics', participants: 423, avgScore: 69.5, completion: 89 }
    ],
    levelDistribution: [
      { level: '10th Grade', users: 4523, percentage: 35.2 },
      { level: '+2 (12th)', users: 5234, percentage: 40.7 },
      { level: 'Degree', users: 3090, percentage: 24.1 }
    ],
    engagementMetrics: {
      dailyActiveUsers: 3245,
      avgSessionTime: '24m 32s',
      bounceRate: '23.4%',
      returnRate: '68.7%'
    }
  };

  return (
    <div className="p-8">
      <div className="mb-8">
        <div className="flex items-center justify-between">
          <div>
            <h1 className="text-3xl font-bold text-gray-900">Analytics Dashboard</h1>
            <p className="text-gray-600 mt-2">Monitor platform performance and user engagement</p>
          </div>
          <div className="flex items-center space-x-4">
            <select
              className="px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              value={timeframe}
              onChange={(e) => setTimeframe(e.target.value)}
            >
              <option value="7d">Last 7 days</option>
              <option value="30d">Last 30 days</option>
              <option value="90d">Last 3 months</option>
              <option value="1y">Last year</option>
            </select>
            <button className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors flex items-center">
              <Download className="w-4 h-4 mr-2" />
              Export Report
            </button>
          </div>
        </div>
      </div>

      {/* Overview Stats */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-8">
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center justify-between">
            <div>
              <p className="text-sm font-medium text-gray-600">Total Users</p>
              <p className="text-2xl font-bold text-gray-900">{analyticsData.overview.totalUsers.value.toLocaleString()}</p>
              <p className="text-sm text-green-600 mt-1">{analyticsData.overview.totalUsers.change} from last period</p>
            </div>
            <div className="bg-blue-500 p-3 rounded-lg">
              <Users className="w-6 h-6 text-white" />
            </div>
          </div>
        </div>
        
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center justify-between">
            <div>
              <p className="text-sm font-medium text-gray-600">Active Exams</p>
              <p className="text-2xl font-bold text-gray-900">{analyticsData.overview.activeExams.value}</p>
              <p className="text-sm text-green-600 mt-1">{analyticsData.overview.activeExams.change} from last period</p>
            </div>
            <div className="bg-green-500 p-3 rounded-lg">
              <BookOpen className="w-6 h-6 text-white" />
            </div>
          </div>
        </div>
        
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center justify-between">
            <div>
              <p className="text-sm font-medium text-gray-600">Exam Participation</p>
              <p className="text-2xl font-bold text-gray-900">{analyticsData.overview.examParticipation.value.toLocaleString()}</p>
              <p className="text-sm text-green-600 mt-1">{analyticsData.overview.examParticipation.change} from last period</p>
            </div>
            <div className="bg-purple-500 p-3 rounded-lg">
              <Target className="w-6 h-6 text-white" />
            </div>
          </div>
        </div>
        
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center justify-between">
            <div>
              <p className="text-sm font-medium text-gray-600">Average Score</p>
              <p className="text-2xl font-bold text-gray-900">{analyticsData.overview.avgScore.value}%</p>
              <p className="text-sm text-green-600 mt-1">{analyticsData.overview.avgScore.change} from last period</p>
            </div>
            <div className="bg-orange-500 p-3 rounded-lg">
              <TrendingUp className="w-6 h-6 text-white" />
            </div>
          </div>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-8 mb-8">
        {/* Top Performing Exams */}
        <div className="bg-white rounded-lg shadow-sm border border-gray-200">
          <div className="p-6 border-b border-gray-200">
            <h2 className="text-lg font-semibold text-gray-900">Top Performing Exams</h2>
          </div>
          <div className="p-6">
            <div className="space-y-4">
              {analyticsData.examStats.map((exam, index) => (
                <div key={index} className="flex items-center justify-between p-4 bg-gray-50 rounded-lg">
                  <div className="flex-1">
                    <p className="font-medium text-gray-900">{exam.name}</p>
                    <p className="text-sm text-gray-600">{exam.participants} participants</p>
                  </div>
                  <div className="text-right">
                    <p className="font-semibold text-gray-900">{exam.avgScore}%</p>
                    <p className="text-sm text-gray-600">{exam.completion}% completion</p>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>

        {/* User Level Distribution */}
        <div className="bg-white rounded-lg shadow-sm border border-gray-200">
          <div className="p-6 border-b border-gray-200">
            <h2 className="text-lg font-semibold text-gray-900">User Distribution by Level</h2>
          </div>
          <div className="p-6">
            <div className="space-y-4">
              {analyticsData.levelDistribution.map((level, index) => (
                <div key={index} className="space-y-2">
                  <div className="flex items-center justify-between">
                    <span className="text-sm font-medium text-gray-700">{level.level}</span>
                    <span className="text-sm text-gray-600">{level.users.toLocaleString()} ({level.percentage}%)</span>
                  </div>
                  <div className="w-full bg-gray-200 rounded-full h-2">
                    <div 
                      className="bg-blue-600 h-2 rounded-full" 
                      style={{ width: `${level.percentage}%` }}
                    />
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>

      {/* Engagement Metrics */}
      <div className="bg-white rounded-lg shadow-sm border border-gray-200">
        <div className="p-6 border-b border-gray-200">
          <h2 className="text-lg font-semibold text-gray-900">Engagement Metrics</h2>
        </div>
        <div className="p-6">
          <div className="grid grid-cols-1 md:grid-cols-4 gap-6">
            <div className="text-center">
              <p className="text-3xl font-bold text-blue-600">{analyticsData.engagementMetrics.dailyActiveUsers.toLocaleString()}</p>
              <p className="text-sm text-gray-600 mt-1">Daily Active Users</p>
            </div>
            <div className="text-center">
              <p className="text-3xl font-bold text-green-600">{analyticsData.engagementMetrics.avgSessionTime}</p>
              <p className="text-sm text-gray-600 mt-1">Avg Session Time</p>
            </div>
            <div className="text-center">
              <p className="text-3xl font-bold text-orange-600">{analyticsData.engagementMetrics.bounceRate}</p>
              <p className="text-sm text-gray-600 mt-1">Bounce Rate</p>
            </div>
            <div className="text-center">
              <p className="text-3xl font-bold text-purple-600">{analyticsData.engagementMetrics.returnRate}</p>
              <p className="text-sm text-gray-600 mt-1">Return Rate</p>
            </div>
          </div>
        </div>
      </div>

      {/* Chart Placeholder */}
      <div className="mt-8 bg-white rounded-lg shadow-sm border border-gray-200">
        <div className="p-6 border-b border-gray-200">
          <div className="flex items-center justify-between">
            <h2 className="text-lg font-semibold text-gray-900">Performance Trends</h2>
            <div className="flex items-center space-x-2">
              <select
                className="px-3 py-1 border border-gray-300 rounded text-sm focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                value={metric}
                onChange={(e) => setMetric(e.target.value)}
              >
                <option value="all">All Metrics</option>
                <option value="users">User Growth</option>
                <option value="exams">Exam Activity</option>
                <option value="scores">Score Trends</option>
              </select>
            </div>
          </div>
        </div>
        <div className="p-6">
          <div className="h-64 bg-gray-50 rounded-lg flex items-center justify-center">
            <p className="text-gray-500">Chart visualization would be rendered here</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Analytics;