import React from 'react';
import { Users, BookOpen, TrendingUp, Award, DollarSign, UserCheck, FileText } from 'lucide-react';

const Dashboard: React.FC = () => {
  const stats = [
    { label: 'Total Users', value: '12,847', icon: Users, color: 'bg-blue-500', change: '+12%' },
    { label: 'Active Exams', value: '156', icon: BookOpen, color: 'bg-green-500', change: '+8%' },
    { label: 'Total Revenue', value: '₹2,45,890', icon: DollarSign, color: 'bg-purple-500', change: '+15%' },
    { label: 'Coordinators', value: '24', icon: UserCheck, color: 'bg-orange-500', change: '+2%' },
  ];

  const recentActivity = [
    { action: 'New exam "JEE Main Mock Test #45" created', time: '2 mins ago', type: 'exam' },
    { action: 'User "student123" completed Biology Test', time: '5 mins ago', type: 'completion' },
    { action: 'Coordinator "coord_physics" added new questions', time: '12 mins ago', type: 'content' },
    { action: 'Current affairs article published', time: '25 mins ago', type: 'content' },
    { action: 'Reward distributed to top 3 performers', time: '1 hour ago', type: 'reward' },
  ];

  return (
    <div className="p-8">
      <div className="mb-8">
        <h1 className="text-3xl font-bold text-gray-900">Dashboard</h1>
        <p className="text-gray-600 mt-2">Welcome back! Here's what's happening on your platform.</p>
      </div>

      {/* Stats Grid */}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
        {stats.map((stat, index) => {
          const Icon = stat.icon;
          return (
            <div key={index} className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
              <div className="flex items-center justify-between">
                <div>
                  <p className="text-sm font-medium text-gray-600">{stat.label}</p>
                  <p className="text-2xl font-bold text-gray-900 mt-1">{stat.value}</p>
                  <p className="text-sm text-green-600 mt-1">{stat.change} from last month</p>
                </div>
                <div className={`${stat.color} p-3 rounded-lg`}>
                  <Icon className="w-6 h-6 text-white" />
                </div>
              </div>
            </div>
          );
        })}
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
        {/* Recent Activity */}
        <div className="bg-white rounded-lg shadow-sm border border-gray-200">
          <div className="p-6 border-b border-gray-200">
            <h2 className="text-lg font-semibold text-gray-900">Recent Activity</h2>
          </div>
          <div className="p-6">
            <div className="space-y-4">
              {recentActivity.map((activity, index) => (
                <div key={index} className="flex items-start space-x-3">
                  <div className={`w-2 h-2 rounded-full mt-2 ${
                    activity.type === 'exam' ? 'bg-blue-500' :
                    activity.type === 'completion' ? 'bg-green-500' :
                    activity.type === 'content' ? 'bg-orange-500' :
                    'bg-purple-500'
                  }`} />
                  <div className="flex-1">
                    <p className="text-sm text-gray-900">{activity.action}</p>
                    <p className="text-xs text-gray-500 mt-1">{activity.time}</p>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>

        {/* Quick Actions */}
        <div className="bg-white rounded-lg shadow-sm border border-gray-200">
          <div className="p-6 border-b border-gray-200">
            <h2 className="text-lg font-semibold text-gray-900">Quick Actions</h2>
          </div>
          <div className="p-6">
            <div className="grid grid-cols-2 gap-4">
              <button className="p-4 border border-gray-300 rounded-lg hover:bg-gray-50 transition-colors text-left">
                <BookOpen className="w-6 h-6 text-blue-600 mb-2" />
                <p className="font-medium text-gray-900">Create Exam</p>
                <p className="text-sm text-gray-600">Add new examination</p>
              </button>
              <button className="p-4 border border-gray-300 rounded-lg hover:bg-gray-50 transition-colors text-left">
                <FileText className="w-6 h-6 text-green-600 mb-2" />
                <p className="font-medium text-gray-900">Add Content</p>
                <p className="text-sm text-gray-600">Publish current affairs</p>
              </button>
              <button className="p-4 border border-gray-300 rounded-lg hover:bg-gray-50 transition-colors text-left">
                <UserCheck className="w-6 h-6 text-purple-600 mb-2" />
                <p className="font-medium text-gray-900">Add Coordinator</p>
                <p className="text-sm text-gray-600">Invite new coordinator</p>
              </button>
              <button className="p-4 border border-gray-300 rounded-lg hover:bg-gray-50 transition-colors text-left">
                <Award className="w-6 h-6 text-orange-600 mb-2" />
                <p className="font-medium text-gray-900">Manage Rewards</p>
                <p className="text-sm text-gray-600">Update reward system</p>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;