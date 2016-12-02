using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Blob;
namespace tmp_matching4
{
    class MyCV
    {
        public void Zero(ref Mat src)
        {
            var indexer = new MatOfByte3(src).GetIndexer();
            for (int x = 0; x < src.Width; x++)
                for (int y = 0; y < src.Height; y++)
                {
                    Vec3b color = indexer[y, x];
                    color.Item0 = 0;
                    color.Item1 = 0;
                    color.Item2 = 0;
                    indexer[y, x] = color;
                }
            indexer = null;

        }

        public void Absdiff_mask(ref Mat dst,Mat src1,Mat src2,Mat mask)
        {
            var indexer1 = new MatOfByte3(src1).GetIndexer();
            var indexer2 = new MatOfByte3(src2).GetIndexer();
            var indexer_mask = new MatOfByte3(mask).GetIndexer();
            var indexer_dst= new MatOfByte3(dst).GetIndexer();

            for (int x = 0; x < dst.Width; x++)
                for (int y = 0; y < dst.Height; y++)
                {
                    int color1 = indexer1[y, x].Item0;
                    int color2 = indexer2[y, x].Item0;
                    int color_mask = indexer_mask[y, x].Item0;

                    var color = indexer_mask[y, x];
                    if (indexer_mask[y, x].Item0 == 0)//マスク画像の黒領域
                        color.Item0 = (byte)Math.Abs(color1 - color2);
                    else
                        color.Item0 = 0;//白領域は比較しない

                    indexer_dst[y, x] =color;
                }
            indexer1 = null;
            indexer2 = null;
            indexer_mask = null;
            indexer_dst = null;
        }
        public void paint_black(ref Mat src,Mat mask)//maskの白領域をsrcの上に黒塗り
        {
            var indexer_src = new MatOfByte3(src).GetIndexer();
            var indexer_mask = new MatOfByte3(mask).GetIndexer();

            for (int x = 0; x < src.Width; x++)
                for (int y = 0; y < src.Height; y++)
                {
                    int color_src = indexer_src[y, x].Item0;
                    int color_mask = indexer_mask[y, x].Item0;

                    var color = indexer_src[y, x];
                    if (indexer_mask[y, x].Item0 != 0)//マスク画像の白領域
                        color.Item0 = 0;
                    indexer_src[y, x] = color;
                }
            indexer_src = null;
            indexer_mask = null;
        }

        public void Add4(ref Mat dst, Mat[] src)
        {
            for (int i = 0; i < 4; i++) Cv2.Add(dst, src[i], dst);
        }

        public void 自作反射光除去(Mat[] images, ref Mat DST)
        {
            int width = images[0].Width;
            int height = images[0].Height;

            MatIndexer<Vec3b>[] indexers = new MatIndexer<Vec3b>[4];
            var indexer = new MatOfByte3(DST).GetIndexer();

            for (int i = 0; i < 4; i++) indexers[i] = new MatOfByte3(images[i]).GetIndexer();//images[i].GetGenericIndexer<Vec3b>();

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    Vec3b[] colors = new Vec3b[4];
                    Vec3b color = indexer[y, x];
                    for (int i = 0; i < 4; i++) colors[i] = indexers[i][y, x];
                    double[] vals = { 0, 0, 0, 0 };
                    for (int num = 0; num < 4; num++) vals[num] = colors[num].Item0;
                    Array.Sort(vals);//並び替えを行う．min=vals[0]
                    color.Item0 = (byte)((vals[0] + vals[1] + vals[2]) / 3.0);
                    indexer[y, x] = color;

                    colors = null;
                }
            indexers = null;
            indexer = null;
        }

        public void コントラスト調整(ref Mat src, double 倍率)
        {
            int width = src.Width;
            int height = src.Height;

            var indexer = new MatOfByte3(src).GetIndexer();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vec3b color = indexer[y, x];
                    double val = color.Item0 * 倍率;
                    if (val > 255) color.Item0 = 255;
                    else if (val < 0) color.Item0 = 0;
                    else color.Item0 = (byte)val;
                    indexer[y, x] = color;
                }
            }
            indexer = null;
        }

        public void 明るさ調整(ref Mat img, double 目標)
        {//中心近くの9ピクセルから輝度調整

            int width = img.Width;
            int height = img.Height;
            int center_x = width / 5;
            int center_y = height / 5;
            //var indexer = img.GetGenericIndexer<Vec3b>();

            double[] vals = new double[9];
            double average = 0;
            double diff = 0;
            var indexer = new MatOfByte3(img).GetIndexer();

            vals[0] = indexer[center_y - 10, center_x - 10].Item0; vals[3] = indexer[center_y - 10, center_x].Item0; vals[6] = indexer[center_y - 10, center_x + 10].Item0;
            vals[1] = indexer[center_y, center_x - 10].Item0; vals[4] = indexer[center_y, center_x].Item0; vals[7] = indexer[center_y, center_x + 10].Item0;
            vals[2] = indexer[center_y + 10, center_x - 10].Item0; vals[5] = indexer[center_y + 10, center_x].Item0; vals[8] = indexer[center_y + 10, center_x + 10].Item0;

            for (int num = 0; num < 9; num++) average += vals[num];
            average = average / 9.0;
            diff = 目標 - average;

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    Vec3b color = indexer[y, x];//indexer[y, x];
                    double val = color.Item0 + diff;
                    if (val > 255) color.Item0 = 255;
                    else if (val < 0) color.Item0 = 0;
                    else color.Item0 = (byte)val;
                    indexer[y, x] = color;//indexer[y, x] = color;
                }
            indexer = null;
        }

        public void TopHat(Mat src, ref Mat dst, int size, int num)
        {
            dst = src.Clone();
            size = 2 * size + 1;
            var kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(size, size));
            Cv2.MorphologyEx(src, dst, MorphTypes.TopHat, kernel, null, num);
        }
        public void 二値化(ref Mat src, int val)
        {
            src = src.Threshold(val, 255, ThresholdTypes.Binary);
        }

        public void 評価用画像作成(Mat テンプレート, Mat 検査結果, ref Mat dst)
        {

            Mat mask = テンプレート.Clone();//この時点では輪郭が白
            Zero(ref dst);

            Cv2.BitwiseNot(テンプレート, mask);//正解画像の輪郭を黒にする
            Cv2.BitwiseAnd(検査結果, 検査結果, dst, mask);

            mask.Dispose();
        }
        public void 評価結果画像作成_debug(Mat 検査結果, Mat テンプレート, int[,] 正解座標, ref Mat color_debug)
        {

            Mat res_color = new Mat(new Size(検査結果.Width, 検査結果.Height), MatType.CV_8UC3, Scalar.All(0));
            var temp_color = res_color.Clone();
            var result_clone = 検査結果.Clone();


            paint_black(ref result_clone, テンプレート);
            CvBlobs blobs = new CvBlobs(result_clone);
            int score = 0;

            blobs.FilterByArea(9, 250);
            blobs.RenderBlobs(result_clone, res_color);

            Cv2.CvtColor(テンプレート, temp_color, ColorConversionCodes.GRAY2BGR);
            Cv2.Add(temp_color, res_color, color_debug);

            点数計算_debug(blobs, 正解座標, ref color_debug, ref score);

            

            res_color = null;
            temp_color=null;
            blobs = null;
            result_clone = null;

        }

        public void 点数計算_debug(CvBlobs blobs, int[,] 正解座標, ref Mat color, ref int score)
        {
            if (正解座標 != null)
            {

                int[,] 正解座標2 = (int[,])正解座標.Clone();
                int 正解数 = 0;
                int 不正解数 = 0;
                int 許容回数 = 5;
                int 未検出数 = 0;

                foreach (CvBlob item in blobs.Values)
                {
                    CvContourPolygon polygon = item.Contour.ConvertToPolygon();
                    Point2f circleCenter;
                    float circleRadius;

                    GetEnclosingCircle(polygon, out circleCenter, out circleRadius);
                    for (int j = 0; j < 正解座標2.Length / 2; j++)
                    {
                        if (正解座標2[j, 0] != 0 && (Math.Pow(circleCenter.X - 正解座標2[j, 0], 2) + Math.Pow(circleCenter.Y - 正解座標2[j, 1], 2) < circleRadius * circleRadius))
                        {//外接円内にあったら
                            Cv2.Circle(color, item.Centroid, (int)circleRadius, new Scalar(0, 0, 255), 2);
                            正解数++;
                            正解座標2[j, 0] = 正解座標2[j, 1] = 0;
                            j = 正解座標2.Length;//ひとつ照合確定したら，このfor文を抜けて次のラベルの検査に移動
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine("未検出座標");
                for (int i = 0; i < 正解座標2.Length / 2; i++)
                {//検出されなかった座標が残る
                    if (正解座標2[i, 0] != 0)
                    {
                        System.Diagnostics.Debug.WriteLine(i + ":" + 正解座標2[i, 0] + "," + 正解座標2[i, 1]);
                        未検出数++;
                    }
                }

                不正解数 = blobs.Count - 正解数;
                if (不正解数 <= 許容回数) score = (int)((float)(正解数) * (10000.0f / (正解座標.Length / 2)));
                else score = (int)((float)(正解数 - (不正解数 - 許容回数)) * (10000.0f / (正解座標.Length / 2)));

                Cv2.PutText(color, "score= " + score.ToString(), new Point(10, 120), HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 0));
                Cv2.PutText(color, "unCorrect= " + 不正解数.ToString(), new Point(10, 140), HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 0));
                Cv2.PutText(color, "unFind= " + 未検出数.ToString(), new Point(10, 160), HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 0));
            }
        }

        public int[] 点数計算(Mat 検査結果,Mat テンプレート, int[,] 正解座標)
        {

            int score = 0;
            var result_clone = 検査結果.Clone();
            paint_black(ref result_clone, テンプレート);

            CvBlobs blobs = new CvBlobs(検査結果);
            blobs.FilterByArea(9, 250);

            int[,] 正解座標2 = (int[,])正解座標.Clone();
            int 正解数 = 0;
            int 不正解数 = 0;
            int 許容回数 = 5;
            int 未検出数 = 0;

            foreach (CvBlob item in blobs.Values)
            {
                CvContourPolygon polygon = item.Contour.ConvertToPolygon();
                Point2f circleCenter;
                float circleRadius;

                GetEnclosingCircle(polygon, out circleCenter, out circleRadius);
                for (int j = 0; j < 正解座標2.Length / 2; j++)
                {
                    if (正解座標2[j, 0] != 0 && (Math.Pow(circleCenter.X - 正解座標2[j, 0], 2) + Math.Pow(circleCenter.Y - 正解座標2[j, 1], 2) < circleRadius * circleRadius))
                    {//外接円内にあったら
                        正解数++;
                        正解座標2[j, 0] = 正解座標2[j, 1] = 0;
                        j = 正解座標2.Length;//ひとつ照合確定したら，このfor文を抜けて次のラベルの検査に移動
                    }
                }
            }

            for (int i = 0; i < 正解座標2.Length / 2; i++)
            {//検出されなかった座標が残る
                if (正解座標2[i, 0] != 0) 未検出数++;
            }

            不正解数 = blobs.Count - 正解数;

            if (不正解数 <= 許容回数) score = (int)((float)(正解数) * (10000.0f / (正解座標.Length / 2)));
            else score = (int)((float)(正解数 - (不正解数 - 許容回数)) * (10000.0f / (正解座標.Length / 2)));

            blobs = null;
            result_clone = null;

            return new int[] { score, 不正解数, 未検出数 };
        }
        public void GetEnclosingCircle(IEnumerable<Point> points, out Point2f center, out float radius)
        {
            var pointsArray = points.ToArray();
            using (var pointsMat = new Mat(pointsArray.Length, 1, MatType.CV_32SC2, pointsArray))
            {
                Cv2.MinEnclosingCircle(pointsMat, out center, out radius);
            }
        }
    }
}
