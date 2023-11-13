/** @type {import('next').NextConfig} */

const nextConfig = {
  async rewrites() {
    return [
      {
        source: '/auth/:path*',
        destination: `${process.env.AUTH_URL}/:path*`,
      },
      {
        source: '/real-estate/:path*',
        destination: `${process.env.REAL_ESTATE}/:path*`,
      },
    ];
  },
};

module.exports = nextConfig;
