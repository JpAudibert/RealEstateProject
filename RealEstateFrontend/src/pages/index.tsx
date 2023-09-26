import router from 'next/router';
import React from 'react';

const Index: React.FC = () => {
  router.push('/home');

  return <div>Index</div>;
};
