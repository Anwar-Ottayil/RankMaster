import React from 'react';
import {
  LayoutDashboard,
  Users,
  BookOpen,
  FileText,
  UserCheck,
  BarChart3,
  Bell,
  Gift,
  LogOut
} from 'lucide-react';

type ActivePage = 'dashboard' | 'users' | 'exams' | 'content' | 'coordinators' | 'analytics' | 'notifications' | 'rewards';

interface SidebarProps {
  activePage: ActivePage;
  setActivePage: (page: ActivePage) => void;
}

const Sidebar: React.FC<SidebarProps> = ({ activePage, setActivePage }) => {
  const menuItems = [
    { id: 'dashboard', label: 'Dashboard', icon: LayoutDashboard },
    { id: 'users', label: 'User Management', icon: Users },
    { id: 'exams', label: 'Exam Management', icon: BookOpen },
    { id: 'content', label: 'Content Management', icon: FileText },
    { id: 'coordinators', label: 'Coordinators', icon: UserCheck },
    { id: 'analytics', label: 'Analytics', icon: BarChart3 },
    { id: 'notifications', label: 'Notifications', icon: Bell },
    { id: 'rewards', label: 'Rewards', icon: Gift },
  ];

  return (
    <div className="fixed left-0 top-0 h-full w-64 bg-white shadow-lg border-r border-gray-200">
      <div className="p-6 border-b border-gray-200">
        <h1 className="text-2xl font-bold text-blue-600">RankMaster</h1>
        <p className="text-sm text-gray-600 mt-1">Admin Panel</p>
      </div>
      
      <nav className="mt-6">
        {menuItems.map((item) => {
          const Icon = item.icon;
          return (
            <button
              key={item.id}
              onClick={() => setActivePage(item.id as ActivePage)}
              className={`w-full flex items-center px-6 py-3 text-left transition-colors duration-200 ${
                activePage === item.id
                  ? 'bg-blue-50 text-blue-600 border-r-2 border-blue-600'
                  : 'text-gray-600 hover:bg-gray-50 hover:text-gray-900'
              }`}
            >
              <Icon className="w-5 h-5 mr-3" />
              {item.label}
            </button>
          );
        })}
      </nav>
      
      <div className="absolute bottom-0 left-0 right-0 p-6 border-t border-gray-200">
        <button className="w-full flex items-center px-4 py-2 text-gray-600 hover:bg-gray-50 rounded-lg transition-colors">
          <LogOut className="w-5 h-5 mr-3" />
          Logout
        </button>
      </div>
    </div>
  );
};

export default Sidebar;