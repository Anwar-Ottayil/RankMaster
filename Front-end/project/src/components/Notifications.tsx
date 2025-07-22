import React, { useState } from 'react';
import { Plus, Send, Bell, Users, BookOpen, Target, Calendar, Eye, Edit, Trash2 } from 'lucide-react';

const Notifications: React.FC = () => {
  const [showCreateModal, setShowCreateModal] = useState(false);
  const [selectedTab, setSelectedTab] = useState('sent');

  const sentNotifications = [
    {
      id: 1,
      title: 'New JEE Main Mock Test Available',
      message: 'A new comprehensive JEE Main mock test has been added. Attempt now to improve your ranking!',
      audience: 'All +2 Students',
      sentDate: '2024-02-10',
      delivered: 5234,
      opened: 3456,
      clicked: 892,
      type: 'exam'
    },
    {
      id: 2,
      title: 'Weekly Current Affairs Update',
      message: 'Stay updated with the latest current affairs for competitive exams. New content published!',
      audience: 'All Users',
      sentDate: '2024-02-08',
      delivered: 12847,
      opened: 8234,
      clicked: 2145,
      type: 'content'
    },
    {
      id: 3,
      title: 'Reward Distribution Complete',
      message: 'Congratulations! Rewards have been distributed to top 3 performers in last weeks challenge.',
      audience: 'Top Performers',
      sentDate: '2024-02-05',
      delivered: 156,
      opened: 142,
      clicked: 98,
      type: 'reward'
    },
    {
      id: 4,
      title: 'System Maintenance Notice',
      message: 'Scheduled maintenance on Sunday 2-4 AM. Platform will be temporarily unavailable.',
      audience: 'All Users',
      sentDate: '2024-02-03',
      delivered: 12847,
      opened: 9567,
      clicked: 234,
      type: 'system'
    }
  ];

  const scheduledNotifications = [
    {
      id: 5,
      title: 'February Month-End Assessment',
      message: 'Prepare for the comprehensive month-end assessment covering all subjects.',
      audience: 'All Registered Users',
      scheduledDate: '2024-02-25',
      scheduledTime: '10:00 AM',
      type: 'exam'
    },
    {
      id: 6,
      title: 'New Study Material Released',
      message: 'Advanced mathematics formulas and shortcuts now available in study materials.',
      audience: '+2 Mathematics Students',
      scheduledDate: '2024-02-20',
      scheduledTime: '09:00 AM',
      type: 'content'
    }
  ];

  return (
    <div className="p-8">
      <div className="mb-8">
        <div className="flex items-center justify-between">
          <div>
            <h1 className="text-3xl font-bold text-gray-900">Notification Center</h1>
            <p className="text-gray-600 mt-2">Broadcast announcements and updates to users</p>
          </div>
          <button
            onClick={() => setShowCreateModal(true)}
            className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors flex items-center"
          >
            <Plus className="w-4 h-4 mr-2" />
            Create Notification
          </button>
        </div>
      </div>

      {/* Quick Stats */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-6">
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-blue-500 p-3 rounded-lg">
              <Send className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Total Sent</p>
              <p className="text-2xl font-bold text-gray-900">1,247</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-green-500 p-3 rounded-lg">
              <Eye className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Open Rate</p>
              <p className="text-2xl font-bold text-gray-900">68.4%</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-purple-500 p-3 rounded-lg">
              <Target className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Click Rate</p>
              <p className="text-2xl font-bold text-gray-900">24.3%</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-orange-500 p-3 rounded-lg">
              <Calendar className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Scheduled</p>
              <p className="text-2xl font-bold text-gray-900">8</p>
            </div>
          </div>
        </div>
      </div>

      {/* Tabs */}
      <div className="mb-6">
        <nav className="flex space-x-8">
          <button
            onClick={() => setSelectedTab('sent')}
            className={`py-2 px-1 border-b-2 font-medium text-sm ${
              selectedTab === 'sent'
                ? 'border-blue-500 text-blue-600'
                : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
            }`}
          >
            Sent Notifications
          </button>
          <button
            onClick={() => setSelectedTab('scheduled')}
            className={`py-2 px-1 border-b-2 font-medium text-sm ${
              selectedTab === 'scheduled'
                ? 'border-blue-500 text-blue-600'
                : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
            }`}
          >
            Scheduled
          </button>
        </nav>
      </div>

      {/* Sent Notifications */}
      {selectedTab === 'sent' && (
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 overflow-hidden">
          <div className="overflow-x-auto">
            <table className="w-full">
              <thead className="bg-gray-50 border-b border-gray-200">
                <tr>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Notification</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Audience</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Sent Date</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Delivered</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Opened</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Clicked</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Actions</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-gray-200">
                {sentNotifications.map((notification) => (
                  <tr key={notification.id} className="hover:bg-gray-50">
                    <td className="py-4 px-6">
                      <div>
                        <div className="font-medium text-gray-900">{notification.title}</div>
                        <div className="text-sm text-gray-500 mt-1">{notification.message}</div>
                        <div className="flex items-center mt-2">
                          <span className={`inline-flex items-center px-2 py-0.5 rounded text-xs font-medium ${
                            notification.type === 'exam' ? 'bg-blue-100 text-blue-800' :
                            notification.type === 'content' ? 'bg-green-100 text-green-800' :
                            notification.type === 'reward' ? 'bg-purple-100 text-purple-800' :
                            'bg-gray-100 text-gray-800'
                          }`}>
                            {notification.type === 'exam' && <BookOpen className="w-3 h-3 mr-1" />}
                            {notification.type === 'content' && <Bell className="w-3 h-3 mr-1" />}
                            {notification.type === 'reward' && <Target className="w-3 h-3 mr-1" />}
                            {notification.type === 'system' && <Users className="w-3 h-3 mr-1" />}
                            {notification.type}
                          </span>
                        </div>
                      </div>
                    </td>
                    <td className="py-4 px-6">
                      <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-gray-100 text-gray-800">
                        {notification.audience}
                      </span>
                    </td>
                    <td className="py-4 px-6 text-gray-900">{notification.sentDate}</td>
                    <td className="py-4 px-6 text-gray-900">{notification.delivered.toLocaleString()}</td>
                    <td className="py-4 px-6">
                      <div className="text-gray-900">{notification.opened.toLocaleString()}</div>
                      <div className="text-xs text-gray-500">
                        {((notification.opened / notification.delivered) * 100).toFixed(1)}%
                      </div>
                    </td>
                    <td className="py-4 px-6">
                      <div className="text-gray-900">{notification.clicked.toLocaleString()}</div>
                      <div className="text-xs text-gray-500">
                        {((notification.clicked / notification.delivered) * 100).toFixed(1)}%
                      </div>
                    </td>
                    <td className="py-4 px-6">
                      <div className="flex items-center space-x-2">
                        <button className="p-1 text-blue-600 hover:bg-blue-50 rounded">
                          <Eye className="w-4 h-4" />
                        </button>
                        <button className="p-1 text-green-600 hover:bg-green-50 rounded">
                          <Edit className="w-4 h-4" />
                        </button>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      )}

      {/* Scheduled Notifications */}
      {selectedTab === 'scheduled' && (
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 overflow-hidden">
          <div className="overflow-x-auto">
            <table className="w-full">
              <thead className="bg-gray-50 border-b border-gray-200">
                <tr>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Notification</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Audience</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Scheduled Date</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Time</th>
                  <th className="text-left py-3 px-6 font-medium text-gray-900">Actions</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-gray-200">
                {scheduledNotifications.map((notification) => (
                  <tr key={notification.id} className="hover:bg-gray-50">
                    <td className="py-4 px-6">
                      <div>
                        <div className="font-medium text-gray-900">{notification.title}</div>
                        <div className="text-sm text-gray-500 mt-1">{notification.message}</div>
                        <div className="flex items-center mt-2">
                          <span className={`inline-flex items-center px-2 py-0.5 rounded text-xs font-medium ${
                            notification.type === 'exam' ? 'bg-blue-100 text-blue-800' :
                            'bg-green-100 text-green-800'
                          }`}>
                            {notification.type === 'exam' && <BookOpen className="w-3 h-3 mr-1" />}
                            {notification.type === 'content' && <Bell className="w-3 h-3 mr-1" />}
                            {notification.type}
                          </span>
                        </div>
                      </div>
                    </td>
                    <td className="py-4 px-6">
                      <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-gray-100 text-gray-800">
                        {notification.audience}
                      </span>
                    </td>
                    <td className="py-4 px-6 text-gray-900">{notification.scheduledDate}</td>
                    <td className="py-4 px-6 text-gray-900">{notification.scheduledTime}</td>
                    <td className="py-4 px-6">
                      <div className="flex items-center space-x-2">
                        <button className="p-1 text-green-600 hover:bg-green-50 rounded">
                          <Edit className="w-4 h-4" />
                        </button>
                        <button className="p-1 text-red-600 hover:bg-red-50 rounded">
                          <Trash2 className="w-4 h-4" />
                        </button>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      )}

      {/* Create Notification Modal */}
      {showCreateModal && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
          <div className="bg-white rounded-lg p-6 w-full max-w-lg">
            <h2 className="text-lg font-semibold text-gray-900 mb-4">Create New Notification</h2>
            <div className="space-y-4">
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Notification Title</label>
                <input
                  type="text"
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                  placeholder="Enter notification title"
                />
              </div>
              
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Message</label>
                <textarea
                  rows={4}
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                  placeholder="Enter your message..."
                />
              </div>

              <div className="grid grid-cols-2 gap-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Audience</label>
                  <select className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
                    <option value="all">All Users</option>
                    <option value="registered">Registered Users Only</option>
                    <option value="10th">10th Grade Students</option>
                    <option value="+2">+2 Students</option>
                    <option value="degree">Degree Students</option>
                    <option value="top-performers">Top Performers</option>
                  </select>
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Type</label>
                  <select className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
                    <option value="general">General</option>
                    <option value="exam">Exam Related</option>
                    <option value="content">Content Update</option>
                    <option value="reward">Reward Notification</option>
                    <option value="system">System Update</option>
                  </select>
                </div>
              </div>

              <div>
                <label className="flex items-center">
                  <input type="checkbox" className="rounded border-gray-300 text-blue-600 shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50" />
                  <span className="ml-2 text-sm text-gray-700">Schedule for later</span>
                </label>
              </div>
            </div>
            <div className="flex items-center justify-end space-x-4 mt-6">
              <button
                onClick={() => setShowCreateModal(false)}
                className="px-4 py-2 text-gray-600 hover:text-gray-800"
              >
                Cancel
              </button>
              <button className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors">
                Send Notification
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default Notifications;