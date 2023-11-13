'use client';

import { useRouter } from 'next/router';
import React from 'react';

const Index: React.FC = () => {
  const router = useRouter();

  router.push('/home');

  return <div>Index</div>;
};

export default Index;
