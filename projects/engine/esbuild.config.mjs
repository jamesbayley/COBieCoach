import * as esbuild from 'esbuild';

await esbuild.build({
  entryPoints: ['./Interop/JS.fs.js'],
  bundle: true,
  minify: true,
  sourcemap: false,
  target: 'es2022',
  outfile: 'fable_build/cobie-coach.min.js',
  globalName: 'COBieCoach',
  format: 'iife'
});

await esbuild.build({
  entryPoints: ['./Interop/JS.fs.js'],
  bundle: true,
  minify: false,
  sourcemap: false,
  target: 'es2022',
  outfile: 'fable_build/cobie-coach.js',
  globalName: 'COBieCoach',
  format: 'iife'
});