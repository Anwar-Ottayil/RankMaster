import React, { useState } from 'react';
import { Plus, Trophy, Gift, DollarSign, Users, TrendingUp, Edit, Eye, Calendar } from 'lucide-react';

const RewardsManagement: React.FC = () => {
  const [showCreateModal, setShowCreateModal] = useState(false);
  const [selectedTab, setSelectedTab] = useState('active');

  const activeRewards = [
    {
      id: 1,
      title: 'February Top Performers',
      description: 'Monthly reward for top 3 performers across all levels',
      type: 'Cash Reward',
      totalPool: 15000,
      positions: 3,
      criteria: 'Highest average score in February',
      endDate: '2024-02-29',
      participants: 8247,
      status: 'Active'
    },
    {
      id: 2,
      title: 'JEE Mock Test Champions',
      description: 'Special reward for JEE mock test top scorers',
      type: 'Scholarship Voucher',
      totalPool: 25000,
      positions: 5,
      criteria: 'Top 5 in JEE mock test series',
      endDate: '2024-02-20',
      participants: 2156,
      status: 'Active'
    },
    {
      id: 3,
      title: 'Weekly Challenge Winners',
      description: 'Weekly rewards for consistent performers',
      type: 'Gift Voucher',
      totalPool: 5000,
      positions: 10,
      criteria: 'Weekly performance consistency',
      endDate: '2024-02-16',
      participants: 4523,
      status: 'Active'
    }
  ];

  const completedRewards = [
    {
      id: 4,
      title: 'January Top Performers',
      description: 'Monthly reward for top 3 performers',
      type: 'Cash Reward',
      totalPool: 15000,
      winners: [
        { rank: 1, name: 'Arjun Sharma', level: '+2', prize: 7500 },
        { rank: 2, name: 'Priya Patel', level: 'Degree', prize: 5000 },
        { rank: 3, name: 'Rahul Kumar', level: '10th', prize: 2500 }
      ],
      completedDate: '2024-01-31',
      status: 'Completed'
    }
  ];

  const walletStats = {
    totalBalance: 150000,
    monthlyBudget: 50000,
    distributedThisMonth: 23450,
    pendingPayouts: 8750
  };

  return (
    <div className="p-8">
      <div className="mb-8">
        <div className="flex items-center justify-between">
          <div>
            <h1 className="text-3xl font-bold text-gray-900">Rewards Management</h1>
            <p className="text-gray-600 mt-2">Manage rewards system and platform wallet</p>
          </div>
          <button
            onClick={() => setShowCreateModal(true)}
            className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors flex items-center"
          >
            <Plus className="w-4 h-4 mr-2" />
            Create Reward
          </button>
        </div>
      </div>

      {/* Wallet Stats */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-8">
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-green-500 p-3 rounded-lg">
              <DollarSign className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Total Balance</p>
              <p className="text-2xl font-bold text-gray-900">₹{walletStats.totalBalance.toLocaleString()}</p>
            </div>
          </div>
        </div>
        
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-blue-500 p-3 rounded-lg">
              <Calendar className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Monthly Budget</p>
              <p className="text-2xl font-bold text-gray-900">₹{walletStats.monthlyBudget.toLocaleString()}</p>
            </div>
          </div>
        </div>
        
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-purple-500 p-3 rounded-lg">
              <TrendingUp className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Distributed</p>
              <p className="text-2xl font-bold text-gray-900">₹{walletStats.distributedThisMonth.toLocaleString()}</p>
            </div>
          </div>
        </div>
        
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-orange-500 p-3 rounded-lg">
              <Gift className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Pending Payouts</p>
              <p className="text-2xl font-bold text-gray-900">₹{walletStats.pendingPayouts.toLocaleString()}</p>
            </div>
          </div>
        </div>
      </div>

      {/* Tabs */}
      <div className="mb-6">
        <nav className="flex space-x-8">
          <button
            onClick={() => setSelectedTab('active')}
            className={`py-2 px-1 border-b-2 font-medium text-sm ${
              selectedTab === 'active'
                ? 'border-blue-500 text-blue-600'
                : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
            }`}
          >
            Active Rewards
          </button>
          <button
            onClick={() => setSelectedTab('completed')}
            className={`py-2 px-1 border-b-2 font-medium text-sm ${
              selectedTab === 'completed'
                ? 'border-blue-500 text-blue-600'
                : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
            }`}
          >
            Completed Rewards
          </button>
          <button
            onClick={() => setSelectedTab('leaderboard')}
            className={`py-2 px-1 border-b-2 font-medium text-sm ${
              selectedTab === 'leaderboard'
                ? 'border-blue-500 text-blue-600'
                : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
            }`}
          >
            Leaderboards
          </button>
        </nav>
      </div>

      {/* Active Rewards */}
      {selectedTab === 'active' && (
        <div className="space-y-6">
          {activeRewards.map((reward) => (
            <div key={reward.id} className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
              <div className="flex items-center justify-between mb-4">
                <div className="flex items-center">
                  <div className="bg-yellow-100 p-2 rounded-lg mr-4">
                    <Trophy className="w-6 h-6 text-yellow-600" />
                  </div>
                  <div>
                    <h3 className="text-lg font-semibold text-gray-900">{reward.title}</h3>
                    <p className="text-gray-600">{reward.description}</p>
                  </div>
                </div>
                <div className="flex items-center space-x-2">
                  <button className="p-2 text-blue-600 hover:bg-blue-50 rounded">
                    <Eye className="w-4 h-4" />
                  </button>
                  <button className="p-2 text-green-600 hover:bg-green-50 rounded">
                    <Edit className="w-4 h-4" />
                  </button>
                </div>
              </div>
              
              <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
                <div>
                  <p className="text-sm font-medium text-gray-600">Reward Type</p>
                  <p className="text-gray-900">{reward.type}</p>
                </div>
                <div>
                  <p className="text-sm font-medium text-gray-600">Total Pool</p>
                  <p className="text-gray-900 font-semibold">₹{reward.totalPool.toLocaleString()}</p>
                </div>
                <div>
                  <p className="text-sm font-medium text-gray-600">Positions</p>
                  <p className="text-gray-900">Top {reward.positions}</p>
                </div>
                <div>
                  <p className="text-sm font-medium text-gray-600">Participants</p>
                  <p className="text-gray-900">{reward.participants.toLocaleString()}</p>
                </div>
              </div>
              
              <div className="mt-4 pt-4 border-t border-gray-200">
                <div className="flex items-center justify-between">
                  <div>
                    <p className="text-sm text-gray-600">Criteria: {reward.criteria}</p>
                    <p className="text-sm text-gray-600">Ends: {reward.endDate}</p>
                  </div>
                  <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-green-100 text-green-800">
                    {reward.status}
                  </span>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      {/* Completed Rewards */}
      {selectedTab === 'completed' && (
        <div className="space-y-6">
          {completedRewards.map((reward) => (
            <div key={reward.id} className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
              <div className="flex items-center justify-between mb-4">
                <div className="flex items-center">
                  <div className="bg-gray-100 p-2 rounded-lg mr-4">
                    <Trophy className="w-6 h-6 text-gray-600" />
                  </div>
                  <div>
                    <h3 className="text-lg font-semibold text-gray-900">{reward.title}</h3>
                    <p className="text-gray-600">{reward.description}</p>
                    <p className="text-sm text-gray-500">Completed on {reward.completedDate}</p>
                  </div>
                </div>
                <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-gray-100 text-gray-800">
                  Completed
                </span>
              </div>
              
              <div className="bg-gray-50 rounded-lg p-4">
                <h4 className="font-medium text-gray-900 mb-3">Winners</h4>
                <div className="space-y-2">
                  {reward.winners.map((winner) => (
                    <div key={winner.rank} className="flex items-center justify-between">
                      <div className="flex items-center">
                        <div className={`w-8 h-8 rounded-full flex items-center justify-center text-white text-sm font-bold mr-3 ${
                          winner.rank === 1 ? 'bg-yellow-500' :
                          winner.rank === 2 ? 'bg-gray-400' :
                          'bg-orange-500'
                        }`}>
                          {winner.rank}
                        </div>
                        <div>
                          <p className="font-medium text-gray-900">{winner.name}</p>
                          <p className="text-sm text-gray-600">{winner.level}</p>
                        </div>
                      </div>
                      <p className="font-semibold text-gray-900">₹{winner.prize.toLocaleString()}</p>
                    </div>
                  ))}
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      {/* Leaderboards */}
      {selectedTab === 'leaderboard' && (
        <div className="bg-white rounded-lg shadow-sm border border-gray-200">
          <div className="p-6 border-b border-gray-200">
            <h2 className="text-lg font-semibold text-gray-900">Current Leaderboard - February Top Performers</h2>
          </div>
          <div className="p-6">
            <div className="space-y-4">
              {[
                { rank: 1, name: 'Vikram Singh', level: '+2', score: 94.2, exams: 23 },
                { rank: 2, name: 'Sneha Reddy', level: 'Degree', score: 92.8, exams: 19 },
                { rank: 3, name: 'Arjun Sharma', level: '10th', score: 91.5, exams: 21 },
                { rank: 4, name: 'Priya Patel', level: '+2', score: 90.3, exams: 18 },
                { rank: 5, name: 'Rahul Kumar', level: 'Degree', score: 89.7, exams: 16 }
              ].map((entry) => (
                <div key={entry.rank} className="flex items-center justify-between p-4 bg-gray-50 rounded-lg">
                  <div className="flex items-center">
                    <div className={`w-10 h-10 rounded-full flex items-center justify-center text-white font-bold mr-4 ${
                      entry.rank === 1 ? 'bg-yellow-500' :
                      entry.rank === 2 ? 'bg-gray-400' :
                      entry.rank === 3 ? 'bg-orange-500' :
                      'bg-blue-500'
                    }`}>
                      {entry.rank}
                    </div>
                    <div>
                      <p className="font-medium text-gray-900">{entry.name}</p>
                      <p className="text-sm text-gray-600">{entry.level} • {entry.exams} exams completed</p>
                    </div>
                  </div>
                  <div className="text-right">
                    <p className="text-xl font-bold text-gray-900">{entry.score}%</p>
                    <p className="text-sm text-gray-600">Avg Score</p>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>
      )}

      {/* Create Reward Modal */}
      {showCreateModal && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
          <div className="bg-white rounded-lg p-6 w-full max-w-lg">
            <h2 className="text-lg font-semibold text-gray-900 mb-4">Create New Reward</h2>
            <div className="space-y-4">
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Reward Title</label>
                <input
                  type="text"
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                  placeholder="Enter reward title"
                />
              </div>
              
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Description</label>
                <textarea
                  rows={3}
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                  placeholder="Describe the reward..."
                />
              </div>

              <div className="grid grid-cols-2 gap-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Reward Type</label>
                  <select className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
                    <option value="cash">Cash Reward</option>
                    <option value="voucher">Gift Voucher</option>
                    <option value="scholarship">Scholarship Voucher</option>
                    <option value="certificate">Certificate</option>
                  </select>
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Total Pool (₹)</label>
                  <input
                    type="number"
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                    placeholder="Enter amount"
                  />
                </div>
              </div>

              <div className="grid grid-cols-2 gap-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Number of Positions</label>
                  <input
                    type="number"
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                    placeholder="e.g., 3"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">End Date</label>
                  <input
                    type="date"
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                  />
                </div>
              </div>

              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Criteria</label>
                <input
                  type="text"
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                  placeholder="e.g., Highest average score in February"
                />
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
                Create Reward
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default RewardsManagement;