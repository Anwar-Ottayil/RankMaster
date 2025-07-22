import React, { useState } from 'react';
import { Plus, Search, Filter, Edit, Trash2, UserCheck, Mail, Shield, Activity } from 'lucide-react';

const CoordinatorManagement: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [filterLevel, setFilterLevel] = useState('all');
  const [filterStatus, setFilterStatus] = useState('all');
  const [showCreateModal, setShowCreateModal] = useState(false);

  const coordinators = [
    {
      id: 1,
      name: 'Dr. Rajesh Kumar',
      email: 'rajesh.kumar@rankmaster.com',
      level: '+2',
      subjects: ['Physics', 'Mathematics'],
      status: 'Active',
      joinDate: '2023-08-15',
      examsCreated: 45,
      questionsAdded: 1247,
      lastActive: '2024-02-10',
      permissions: ['Create Exams', 'Manage Questions', 'View Analytics']
    },
    {
      id: 2,
      name: 'Prof. Meena Sharma',
      email: 'meena.sharma@rankmaster.com',
      level: '10th',
      subjects: ['Biology', 'Chemistry'],
      status: 'Active',
      joinDate: '2023-09-22',
      examsCreated: 32,
      questionsAdded: 856,
      lastActive: '2024-02-11',
      permissions: ['Create Exams', 'Manage Questions']
    },
    {
      id: 3,
      name: 'Dr. Anil Verma',
      email: 'anil.verma@rankmaster.com',
      level: 'Degree',
      subjects: ['Computer Science', 'Mathematics'],
      status: 'Active',
      joinDate: '2023-07-10',
      examsCreated: 28,
      questionsAdded: 623,
      lastActive: '2024-02-09',
      permissions: ['Create Exams', 'Manage Questions', 'View Analytics', 'Manage Content']
    },
    {
      id: 4,
      name: 'Ms. Priyanka Singh',
      email: 'priyanka.singh@rankmaster.com',
      level: '+2',
      subjects: ['English', 'History'],
      status: 'Suspended',
      joinDate: '2023-11-05',
      examsCreated: 12,
      questionsAdded: 234,
      lastActive: '2024-01-28',
      permissions: ['Create Exams']
    }
  ];

  const filteredCoordinators = coordinators.filter(coordinator => {
    const matchesSearch = coordinator.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
                         coordinator.email.toLowerCase().includes(searchTerm.toLowerCase()) ||
                         coordinator.subjects.some(subject => subject.toLowerCase().includes(searchTerm.toLowerCase()));
    const matchesLevel = filterLevel === 'all' || coordinator.level === filterLevel;
    const matchesStatus = filterStatus === 'all' || coordinator.status.toLowerCase() === filterStatus.toLowerCase();
    
    return matchesSearch && matchesLevel && matchesStatus;
  });

  return (
    <div className="p-8">
      <div className="mb-8">
        <div className="flex items-center justify-between">
          <div>
            <h1 className="text-3xl font-bold text-gray-900">Coordinator Management</h1>
            <p className="text-gray-600 mt-2">Manage coordinators, permissions, and monitor activities</p>
          </div>
          <button
            onClick={() => setShowCreateModal(true)}
            className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors flex items-center"
          >
            <Plus className="w-4 h-4 mr-2" />
            Add Coordinator
          </button>
        </div>
      </div>

      {/* Quick Stats */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-6">
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-blue-500 p-3 rounded-lg">
              <UserCheck className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Total Coordinators</p>
              <p className="text-2xl font-bold text-gray-900">24</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-green-500 p-3 rounded-lg">
              <Activity className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Active</p>
              <p className="text-2xl font-bold text-gray-900">21</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-purple-500 p-3 rounded-lg">
              <Shield className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Exams Created</p>
              <p className="text-2xl font-bold text-gray-900">389</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-orange-500 p-3 rounded-lg">
              <Edit className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Questions Added</p>
              <p className="text-2xl font-bold text-gray-900">12.4K</p>
            </div>
          </div>
        </div>
      </div>

      {/* Filters */}
      <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6 mb-6">
        <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
          <div className="relative">
            <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5" />
            <input
              type="text"
              placeholder="Search coordinators..."
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
          
          <button className="bg-gray-100 text-gray-700 px-4 py-2 rounded-lg hover:bg-gray-200 transition-colors flex items-center">
            <Filter className="w-4 h-4 mr-2" />
            Permission Filter
          </button>
        </div>
      </div>

      {/* Coordinators Table */}
      <div className="bg-white rounded-lg shadow-sm border border-gray-200 overflow-hidden">
        <div className="overflow-x-auto">
          <table className="w-full">
            <thead className="bg-gray-50 border-b border-gray-200">
              <tr>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Coordinator</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Level</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Subjects</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Status</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Activity</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Last Active</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Actions</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-200">
              {filteredCoordinators.map((coordinator) => (
                <tr key={coordinator.id} className="hover:bg-gray-50">
                  <td className="py-4 px-6">
                    <div>
                      <div className="font-medium text-gray-900">{coordinator.name}</div>
                      <div className="text-sm text-gray-500">{coordinator.email}</div>
                      <div className="text-xs text-gray-400">
                        Joined: {coordinator.joinDate}
                      </div>
                    </div>
                  </td>
                  <td className="py-4 px-6">
                    <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800">
                      {coordinator.level}
                    </span>
                  </td>
                  <td className="py-4 px-6">
                    <div className="flex flex-wrap gap-1">
                      {coordinator.subjects.map((subject, index) => (
                        <span 
                          key={index}
                          className="inline-flex items-center px-2 py-0.5 rounded text-xs font-medium bg-gray-100 text-gray-800"
                        >
                          {subject}
                        </span>
                      ))}
                    </div>
                  </td>
                  <td className="py-4 px-6">
                    <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                      coordinator.status === 'Active' ? 'bg-green-100 text-green-800' : 'bg-red-100 text-red-800'
                    }`}>
                      {coordinator.status}
                    </span>
                  </td>
                  <td className="py-4 px-6">
                    <div className="text-sm text-gray-900">
                      <div>{coordinator.examsCreated} exams</div>
                      <div className="text-xs text-gray-500">{coordinator.questionsAdded} questions</div>
                    </div>
                  </td>
                  <td className="py-4 px-6 text-sm text-gray-900">{coordinator.lastActive}</td>
                  <td className="py-4 px-6">
                    <div className="flex items-center space-x-2">
                      <button className="p-1 text-blue-600 hover:bg-blue-50 rounded" title="Send Message">
                        <Mail className="w-4 h-4" />
                      </button>
                      <button className="p-1 text-green-600 hover:bg-green-50 rounded" title="Edit Coordinator">
                        <Edit className="w-4 h-4" />
                      </button>
                      <button className="p-1 text-purple-600 hover:bg-purple-50 rounded" title="Manage Permissions">
                        <Shield className="w-4 h-4" />
                      </button>
                      <button className="p-1 text-red-600 hover:bg-red-50 rounded" title="Remove Coordinator">
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

      {/* Create Coordinator Modal */}
      {showCreateModal && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
          <div className="bg-white rounded-lg p-6 w-full max-w-lg">
            <h2 className="text-lg font-semibold text-gray-900 mb-4">Add New Coordinator</h2>
            <div className="space-y-4">
              <div className="grid grid-cols-2 gap-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Full Name</label>
                  <input
                    type="text"
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                    placeholder="Enter full name"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Email Address</label>
                  <input
                    type="email"
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                    placeholder="Enter email address"
                  />
                </div>
              </div>
              
              <div className="grid grid-cols-2 gap-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Assigned Level</label>
                  <select className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
                    <option value="">Select Level</option>
                    <option value="10th">10th Grade</option>
                    <option value="+2">+2 (12th Grade)</option>
                    <option value="Degree">Degree</option>
                  </select>
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700 mb-1">Primary Subject</label>
                  <select className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
                    <option value="">Select Subject</option>
                    <option value="Mathematics">Mathematics</option>
                    <option value="Physics">Physics</option>
                    <option value="Chemistry">Chemistry</option>
                    <option value="Biology">Biology</option>
                    <option value="English">English</option>
                    <option value="Computer Science">Computer Science</option>
                  </select>
                </div>
              </div>

              <div>
                <label className="block text-sm font-medium text-gray-700 mb-2">Permissions</label>
                <div className="space-y-2">
                  <label className="flex items-center">
                    <input type="checkbox" className="rounded border-gray-300 text-blue-600 shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50" />
                    <span className="ml-2 text-sm text-gray-700">Create and manage exams</span>
                  </label>
                  <label className="flex items-center">
                    <input type="checkbox" className="rounded border-gray-300 text-blue-600 shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50" />
                    <span className="ml-2 text-sm text-gray-700">Manage question banks</span>
                  </label>
                  <label className="flex items-center">
                    <input type="checkbox" className="rounded border-gray-300 text-blue-600 shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50" />
                    <span className="ml-2 text-sm text-gray-700">View analytics and reports</span>
                  </label>
                  <label className="flex items-center">
                    <input type="checkbox" className="rounded border-gray-300 text-blue-600 shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50" />
                    <span className="ml-2 text-sm text-gray-700">Manage content and materials</span>
                  </label>
                </div>
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
                Add Coordinator
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default CoordinatorManagement;