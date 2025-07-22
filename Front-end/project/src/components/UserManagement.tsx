import React, { useState } from 'react';
import { Search, Filter, MoreVertical, Ban, CheckCircle, Mail } from 'lucide-react';

const UserManagement: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [filterLevel, setFilterLevel] = useState('all');
  const [filterStatus, setFilterStatus] = useState('all');

  const users = [
    { id: 1, name: 'Arjun Sharma', email: 'arjun@example.com', level: '10th', type: 'Registered', status: 'Active', joinDate: '2024-01-15', examsCompleted: 23 },
    { id: 2, name: 'Priya Patel', email: 'priya@example.com', level: '+2', type: 'Registered', status: 'Active', joinDate: '2024-02-03', examsCompleted: 18 },
    { id: 3, name: 'Rahul Kumar', email: 'rahul@example.com', level: 'Degree', type: 'Guest', status: 'Active', joinDate: '2024-01-28', examsCompleted: 5 },
    { id: 4, name: 'Sneha Reddy', email: 'sneha@example.com', level: '10th', type: 'Registered', status: 'Suspended', joinDate: '2023-12-10', examsCompleted: 31 },
    { id: 5, name: 'Vikram Singh', email: 'vikram@example.com', level: '+2', type: 'Registered', status: 'Active', joinDate: '2024-02-20', examsCompleted: 12 },
  ];

  const filteredUsers = users.filter(user => {
    const matchesSearch = user.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
                         user.email.toLowerCase().includes(searchTerm.toLowerCase());
    const matchesLevel = filterLevel === 'all' || user.level === filterLevel;
    const matchesStatus = filterStatus === 'all' || user.status.toLowerCase() === filterStatus.toLowerCase();
    
    return matchesSearch && matchesLevel && matchesStatus;
  });

  return (
    <div className="p-8">
      <div className="mb-8">
        <h1 className="text-3xl font-bold text-gray-900">User Management</h1>
        <p className="text-gray-600 mt-2">Manage and monitor all platform users</p>
      </div>

      {/* Filters and Search */}
      <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6 mb-6">
        <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
          <div className="relative">
            <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5" />
            <input
              type="text"
              placeholder="Search users..."
              className="w-full pl-10 pr-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
            />
          </div>
          
          <select
            className="px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
            value={filterLevel}
            onChange={(e) => setFilterLevel(e.target.value)}
          >
            <option value="all">All Levels</option>
            <option value="10th">10th Grade</option>
            <option value="+2">+2 (12th Grade)</option>
            <option value="Degree">Degree</option>
          </select>
          
          <select
            className="px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
            value={filterStatus}
            onChange={(e) => setFilterStatus(e.target.value)}
          >
            <option value="all">All Status</option>
            <option value="active">Active</option>
            <option value="suspended">Suspended</option>
          </select>
          
          <button className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors flex items-center">
            <Filter className="w-4 h-4 mr-2" />
            Advanced Filter
          </button>
        </div>
      </div>

      {/* Users Table */}
      <div className="bg-white rounded-lg shadow-sm border border-gray-200 overflow-hidden">
        <div className="overflow-x-auto">
          <table className="w-full">
            <thead className="bg-gray-50 border-b border-gray-200">
              <tr>
                <th className="text-left py-3 px-6 font-medium text-gray-900">User</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Level</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Type</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Status</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Exams</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Join Date</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Actions</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-200">
              {filteredUsers.map((user) => (
                <tr key={user.id} className="hover:bg-gray-50">
                  <td className="py-4 px-6">
                    <div>
                      <div className="font-medium text-gray-900">{user.name}</div>
                      <div className="text-sm text-gray-500">{user.email}</div>
                    </div>
                  </td>
                  <td className="py-4 px-6">
                    <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800">
                      {user.level}
                    </span>
                  </td>
                  <td className="py-4 px-6">
                    <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                      user.type === 'Registered' ? 'bg-green-100 text-green-800' : 'bg-gray-100 text-gray-800'
                    }`}>
                      {user.type}
                    </span>
                  </td>
                  <td className="py-4 px-6">
                    <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                      user.status === 'Active' ? 'bg-green-100 text-green-800' : 'bg-red-100 text-red-800'
                    }`}>
                      {user.status}
                    </span>
                  </td>
                  <td className="py-4 px-6 text-gray-900">{user.examsCompleted}</td>
                  <td className="py-4 px-6 text-gray-900">{user.joinDate}</td>
                  <td className="py-4 px-6">
                    <div className="flex items-center space-x-2">
                      <button className="p-1 text-blue-600 hover:bg-blue-50 rounded">
                        <Mail className="w-4 h-4" />
                      </button>
                      <button className={`p-1 rounded ${
                        user.status === 'Active' ? 'text-red-600 hover:bg-red-50' : 'text-green-600 hover:bg-green-50'
                      }`}>
                        {user.status === 'Active' ? <Ban className="w-4 h-4" /> : <CheckCircle className="w-4 h-4" />}
                      </button>
                      <button className="p-1 text-gray-600 hover:bg-gray-50 rounded">
                        <MoreVertical className="w-4 h-4" />
                      </button>
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      {/* Pagination */}
      <div className="mt-6 flex items-center justify-between">
        <p className="text-sm text-gray-600">
          Showing {filteredUsers.length} of {users.length} users
        </p>
        <div className="flex space-x-2">
          <button className="px-3 py-1 border border-gray-300 rounded hover:bg-gray-50">Previous</button>
          <button className="px-3 py-1 bg-blue-600 text-white rounded">1</button>
          <button className="px-3 py-1 border border-gray-300 rounded hover:bg-gray-50">2</button>
          <button className="px-3 py-1 border border-gray-300 rounded hover:bg-gray-50">Next</button>
        </div>
      </div>
    </div>
  );
};

export default UserManagement;