import React, { useState } from 'react';
import { Plus, Search, Filter, Edit, Trash2, Eye, EyeOff, Calendar, Clock, Users } from 'lucide-react';

const ExamManagement: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [filterLevel, setFilterLevel] = useState('all');
  const [filterStatus, setFilterStatus] = useState('all');
  const [showCreateModal, setShowCreateModal] = useState(false);

  const exams = [
    {
      id: 1,
      title: 'JEE Main Mock Test #45',
      level: '+2',
      type: 'Mock Test',
      status: 'Active',
      questions: 90,
      duration: 180,
      participants: 1247,
      scheduledDate: '2024-02-15',
      answerKeyVisible: true,
      isPaid: true
    },
    {
      id: 2,
      title: 'NEET Biology Practice',
      level: '+2', 
      type: 'Practice',
      status: 'Active',
      questions: 45,
      duration: 60,
      participants: 856,
      scheduledDate: '2024-02-10',
      answerKeyVisible: false,
      isPaid: false
    },
    {
      id: 3,
      title: 'Class 10 Mathematics',
      level: '10th',
      type: 'Chapter Test',
      status: 'Draft',
      questions: 30,
      duration: 90,
      participants: 0,
      scheduledDate: '2024-02-20',
      answerKeyVisible: true,
      isPaid: true
    },
    {
      id: 4,
      title: 'Degree Physics Fundamentals',
      level: 'Degree',
      type: 'Assessment',
      status: 'Completed',
      questions: 50,
      duration: 120,
      participants: 423,
      scheduledDate: '2024-02-05',
      answerKeyVisible: true,
      isPaid: true
    }
  ];

  const filteredExams = exams.filter(exam => {
    const matchesSearch = exam.title.toLowerCase().includes(searchTerm.toLowerCase());
    const matchesLevel = filterLevel === 'all' || exam.level === filterLevel;
    const matchesStatus = filterStatus === 'all' || exam.status.toLowerCase() === filterStatus.toLowerCase();
    
    return matchesSearch && matchesLevel && matchesStatus;
  });

  return (
    <div className="p-8">
      <div className="mb-8">
        <div className="flex items-center justify-between">
          <div>
            <h1 className="text-3xl font-bold text-gray-900">Exam Management</h1>
            <p className="text-gray-600 mt-2">Create, schedule and manage platform exams</p>
          </div>
          <button
            onClick={() => setShowCreateModal(true)}
            className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors flex items-center"
          >
            <Plus className="w-4 h-4 mr-2" />
            Create Exam
          </button>
        </div>
      </div>

      {/* Quick Stats */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-6">
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-blue-500 p-3 rounded-lg">
              <Users className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Total Exams</p>
              <p className="text-2xl font-bold text-gray-900">156</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-green-500 p-3 rounded-lg">
              <Calendar className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Scheduled</p>
              <p className="text-2xl font-bold text-gray-900">23</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-orange-500 p-3 rounded-lg">
              <Clock className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Active</p>
              <p className="text-2xl font-bold text-gray-900">87</p>
            </div>
          </div>
        </div>
        <div className="bg-white rounded-lg shadow-sm border border-gray-200 p-6">
          <div className="flex items-center">
            <div className="bg-purple-500 p-3 rounded-lg">
              <Users className="w-6 h-6 text-white" />
            </div>
            <div className="ml-4">
              <p className="text-sm font-medium text-gray-600">Participants</p>
              <p className="text-2xl font-bold text-gray-900">8,247</p>
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
              placeholder="Search exams..."
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
            <option value="draft">Draft</option>
            <option value="completed">Completed</option>
          </select>
          
          <button className="bg-gray-100 text-gray-700 px-4 py-2 rounded-lg hover:bg-gray-200 transition-colors flex items-center">
            <Filter className="w-4 h-4 mr-2" />
            More Filters
          </button>
        </div>
      </div>

      {/* Exams Table */}
      <div className="bg-white rounded-lg shadow-sm border border-gray-200 overflow-hidden">
        <div className="overflow-x-auto">
          <table className="w-full">
            <thead className="bg-gray-50 border-b border-gray-200">
              <tr>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Exam Details</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Level</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Status</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Questions</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Duration</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Participants</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Answer Key</th>
                <th className="text-left py-3 px-6 font-medium text-gray-900">Actions</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-200">
              {filteredExams.map((exam) => (
                <tr key={exam.id} className="hover:bg-gray-50">
                  <td className="py-4 px-6">
                    <div>
                      <div className="font-medium text-gray-900">{exam.title}</div>
                      <div className="text-sm text-gray-500">{exam.type} • {exam.scheduledDate}</div>
                      <div className="text-xs text-gray-400">
                        {exam.isPaid ? 'Paid Exam' : 'Free Exam'}
                      </div>
                    </div>
                  </td>
                  <td className="py-4 px-6">
                    <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800">
                      {exam.level}
                    </span>
                  </td>
                  <td className="py-4 px-6">
                    <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                      exam.status === 'Active' ? 'bg-green-100 text-green-800' :
                      exam.status === 'Draft' ? 'bg-yellow-100 text-yellow-800' :
                      'bg-gray-100 text-gray-800'
                    }`}>
                      {exam.status}
                    </span>
                  </td>
                  <td className="py-4 px-6 text-gray-900">{exam.questions}</td>
                  <td className="py-4 px-6 text-gray-900">{exam.duration} min</td>
                  <td className="py-4 px-6 text-gray-900">{exam.participants.toLocaleString()}</td>
                  <td className="py-4 px-6">
                    <button className={`p-1 rounded ${exam.answerKeyVisible ? 'text-green-600' : 'text-gray-400'}`}>
                      {exam.answerKeyVisible ? <Eye className="w-4 h-4" /> : <EyeOff className="w-4 h-4" />}
                    </button>
                  </td>
                  <td className="py-4 px-6">
                    <div className="flex items-center space-x-2">
                      <button className="p-1 text-blue-600 hover:bg-blue-50 rounded">
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

      {/* Create Exam Modal */}
      {showCreateModal && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
          <div className="bg-white rounded-lg p-6 w-full max-w-md">
            <h2 className="text-lg font-semibold text-gray-900 mb-4">Create New Exam</h2>
            <div className="space-y-4">
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Exam Title</label>
                <input
                  type="text"
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent"
                  placeholder="Enter exam title"
                />
              </div>
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Level</label>
                <select className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
                  <option value="10th">10th Grade</option>
                  <option value="+2">+2 (12th Grade)</option>
                  <option value="Degree">Degree</option>
                </select>
              </div>
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Exam Type</label>
                <select className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
                  <option value="Mock Test">Mock Test</option>
                  <option value="Practice">Practice</option>
                  <option value="Chapter Test">Chapter Test</option>
                  <option value="Assessment">Assessment</option>
                </select>
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
                Create Exam
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default ExamManagement;